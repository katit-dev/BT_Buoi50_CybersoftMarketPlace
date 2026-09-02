using dotnet06_CybersoftMarketPlace.Application.DTOs;

public interface IOrderService
{
    Task<HTTPResponseData<List<OrderHistoryDTO>>>
    GetMyOrdersAsync(string userId);
}