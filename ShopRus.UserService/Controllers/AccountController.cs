using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopRus.UserService.Domain.Models;
using ShopRus.UserService.Infrastructure.Services.Interface;

namespace ShopRus.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public AccountController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }
        public IActionResult Login(SignInRequestModel signInRequest)
        {
            var signInResult = _userLoginService.SignIn(signInRequest.Email, signInRequest.Password);
            if (signInResult.Succeeded)
                return Ok(signInResult);
            else
                return BadRequest(signInResult);
        }
    }
}
