using dotnet06_CybersoftMarketPlace.Application.DTOs;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


public interface IOrderService
{
    Task<HTTPResponseData<List<OrderHistoryDTO>>>
        GetMyOrdersAsync(string userId);
}



public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;


    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    public async Task<HTTPResponseData<List<OrderHistoryDTO>>>
        GetMyOrdersAsync(string userId)
    {
        try
        {
            // Lấy danh sách order của user hiện tại
            // UserId được lấy từ JWT Token

            IQueryable<Order> query =
                await _unitOfWork
                .OrderRepository
                .Where(
                    x =>
                    x.BuyerId.ToString() == userId
                    &&
                    x.Deleted == false
                );



            // Include dữ liệu liên quan
            // Tránh lỗi N+1 Query

            List<Order> orders =
                await query

                .Include(x => x.OrderItems)

                    .ThenInclude(x => x.Variant)

                        .ThenInclude(x => x.Product)

                // Chỉ đọc dữ liệu
                .AsNoTracking()

                .ToListAsync();



            List<OrderHistoryDTO> result =
                new List<OrderHistoryDTO>();



            foreach(Order order in orders)
            {
                OrderHistoryDTO orderDTO =
                    new OrderHistoryDTO();



                orderDTO.OrderId =
                    order.Id;



                orderDTO.CreatedAt =
                    order.CreatedAt
                    ??
                    DateTime.Now;



                orderDTO.TotalAmount =
                    order.TotalAmount;



                // Model Order không có Status
                // Tự xử lý theo yêu cầu đề

                orderDTO.Status =
                    "Processing";



                foreach(OrderItem item in order.OrderItems)
                {
                    OrderHistoryItemDTO itemDTO =
                        new OrderHistoryItemDTO();



                    itemDTO.VariantId =
                        item.VariantId;



                    // Variant -> Product -> Name

                    itemDTO.ProductName =
                        item.Variant.Product.Name;



                    // ProductVariant sử dụng VariantName

                    itemDTO.VariantName =
                        item.Variant.VariantName
                        ??
                        "";



                    // Lấy ảnh từ ProductVariant

                    itemDTO.ImageUrl =
                        item.Variant.Image
                        ??
                        "";



                    itemDTO.Quantity =
                        item.Quantity;



                    itemDTO.UnitPrice =
                        item.UnitPrice;



                    // Backend tính SubTotal

                    itemDTO.SubTotal =
                        item.Quantity
                        *
                        item.UnitPrice;



                    orderDTO.Items.Add(itemDTO);
                }



                result.Add(orderDTO);
            }




            return new HTTPResponseData<List<OrderHistoryDTO>>
            {
                DataResponse = result,

                Message =
                    OrderResponseMessageDTO.GetMyOrdersSuccess,

                statusCode = 200,

                Timestamp = DateTime.Now
            };
        }


        catch(Exception)
        {
            return new HTTPResponseData<List<OrderHistoryDTO>>
            {
                DataResponse = null,

                Message =
                    OrderResponseMessageDTO.GetMyOrdersFailed,

                statusCode = 500,

                Timestamp = DateTime.Now
            };
        }
    }
}