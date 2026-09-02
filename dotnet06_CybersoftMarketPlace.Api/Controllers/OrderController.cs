using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet06_CybersoftMarketPlace.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using dotnet06_CybersoftMarketPlace.Api.Models;

namespace dotnet06_CybersoftMarketPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;


        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("myOrders")]
        public async Task<IActionResult> GetMyOrders()
        {
            string userId = HttpContext.User.Identity.Name;

            HTTPResponseData<List<OrderHistoryDTO>> response = await _orderService.GetMyOrdersAsync(userId);

            return StatusCode(response.statusCode, response);
        }


    }
}