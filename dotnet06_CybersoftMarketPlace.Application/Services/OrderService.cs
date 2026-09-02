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

            // Lấy danh sách order của chính user đang đăng nhập
            // UserId lấy từ JWT -> truyền xuống service
            IQueryable<Order> query =
                await _unitOfWork
                .OrderRepository
                .Where(
                    x =>
                    x.BuyerId.ToString() == userId
                    &&
                    x.Deleted == false
                );



            // Include tránh lỗi N+1 Query
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
                // tự xử lý theo yêu cầu đề
                orderDTO.Status =
                    "Đang xử lý";




                foreach(OrderItem item in order.OrderItems)
                {

                    OrderHistoryItemDTO itemDTO =
                        new OrderHistoryItemDTO();



                    itemDTO.VariantId =
                        item.VariantId;



                    // Variant -> Product -> Name
                    itemDTO.ProductName =
                        item.Variant.Product.Name;



                    // ProductVariant không có Name
                    itemDTO.VariantName =
                        item.Variant.VariantName
                        ??
                        "";



                    // Lấy ảnh của Variant
                    itemDTO.ImageUrl =
                        item.Variant.Image
                        ??
                        "";



                    itemDTO.Quantity =
                        item.Quantity;



                    itemDTO.UnitPrice =
                        item.UnitPrice;



                    // Backend tự tính SubTotal
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
                    "Lấy danh sách đơn mua thành công",

                statusCode = 200,

                Timestamp = DateTime.Now

            };

        }
        catch(Exception ex)
        {

            return new HTTPResponseData<List<OrderHistoryDTO>>
            {

                DataResponse = null,

                Message = ex.Message,

                statusCode = 500,

                Timestamp = DateTime.Now

            };

        }

    }

}
