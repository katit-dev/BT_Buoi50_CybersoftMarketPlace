using dotnet06_CybersoftMarketPlace.Application.DTOs;
using Microsoft.JSInterop;


public class OrderStateService
{

    private readonly HttpClient _httpClient;

    private readonly ILocalStorageService _localStorageService;



    public OrderStateService(
        IHttpClientFactory httpClientFactory,
        ILocalStorageService localStorageService)
    {

        _httpClient =
            httpClientFactory
            .CreateClient("CybersoftMarketplaceApi");


        _localStorageService =
            localStorageService;

    }





    public async Task<
        HTTPResponseData<List<OrderHistoryDTO>>?>
        GetMyOrdersAsync()
    {

        string? token =
            await _localStorageService
            .GetItemAsync<string>("accessToken");



        if(token == null)
        {
            return null;
        }



        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer",
                token
            );



        HttpResponseMessage response =
            await _httpClient.GetAsync(
                "/api/Order/myOrders"
            );



        HTTPResponseData<List<OrderHistoryDTO>>?
            responseData =
            await response.Content
            .ReadFromJsonAsync
            <HTTPResponseData<List<OrderHistoryDTO>>>();



        return responseData;
    }

}