using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Entity.Dtos;
using InvoiceManagementSystem.Entity.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginDto)
        {
            var result = _authService.Login(loginDto);
            return Ok(result);

        }

        [HttpPost("registerforadmin")]
        public IActionResult Register(UserRegisterAdminstratorDto registerAdminstratorDto)
        {
            var result = _authService.RegisterForAdmin(registerAdminstratorDto);
            return Ok(result);
        }

        [HttpPost("passwordreset")]
        public IActionResult PasswordRest(LoginDto loginDto)
        {
            var result = _authService.PasswordReset(loginDto);
            return Ok(result);
        }

        [HttpPost("changeuserpassword")]
        public IActionResult ChangeUserPassword(ChangePasswordWithDto dto)
        {
            var result = _authService.ChangeUserPassword(dto);
            return Ok(result);
        }

        [HttpPost("checksecuritiescode")]
        public IActionResult CheckSecuritiesCode(SecuritiesResponseDto authSecurityResponseDto)
        {
            var result = _authService.CheckSecuritiesCode(authSecurityResponseDto);
            return Ok(result);
        }

        [HttpPost("checkcodes")]
        public IActionResult CheckCodes(SecuritiesResponseDto authSecurityResponseDto)
        {
            var result = _authService.CheckCodes(authSecurityResponseDto);
            return Ok(result);
        }
    }

}
