using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Infrastructure.Models;
using backend_netcore_dotnet06.Helper;
using dotnet06_CybersoftMarketPlace.Application.DTOs;
namespace dotnet06_CybersoftMarketPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        //Chỉ làm việc với service, không làm việc trực tiếp với repository
        private readonly JwtAuthService _jwtService;

        public UserController(IUserService userService, JwtAuthService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        /// <summary>
        /// Tạo user từ view đăng ký tài khoản người dùng
        /// </summary>
        /// <param name="model">Thông tin đăng ký của người dùng</param>
        /// <returns>Trả về kết quả đăng ký</returns>
        [ProducesResponseType(
            StatusCodes.Status201Created,
            Type = typeof(HTTPResponseData<string>)
        )]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest,
            Type = typeof(HTTPResponseData<string>)
        )]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {
            HTTPResponseData<string>? response =
                await _userService.RegisterUserAsync(model);

            return StatusCode(response.statusCode, response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            HTTPResponseData<string>? response =
                await _userService.LoginUserAsync(model);

            return StatusCode(response.statusCode, response);
        }

        [Authorize]
        [HttpPost("getProfile")]
        public async Task<IActionResult> GetProfile()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString()
                .Replace("Bearer ", "");

            HTTPResponseData<ProfileUserDTO>? response =
                await _userService.GetProfileAsync(token);

            return StatusCode(response.statusCode, response);
        }

        [Authorize]
        [HttpPut("updateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO model)
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            HTTPResponseData<ProfileUserDTO>? response = await _userService.UpdateProfileAsync(model, token);
            return StatusCode(response.statusCode, response);
        }

        [Authorize]
        [HttpPut("updateAvatar")]
        public async Task<IActionResult> UpdateAvatar(UpdateAvatarDTO model)
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            HTTPResponseData<ProfileUserDTO> response = await _userService.UpdateAvatarAsync(model, token);

            return StatusCode(response.statusCode, response);
        }

        [Authorize]
        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            string userId = HttpContext.User.Identity.Name;

            HTTPResponseData<string> response = await _userService.ChangePasswordAsync(userId, model);

            return StatusCode(response.statusCode, response);
        }

    }
}