using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Cores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService service;

        public AccountController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await service.RegisterAsync(model);

            if(!result.IsAuthantication)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await service.GetTokenAsync(model);

            if (!result.IsAuthantication)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("AddToRole")]
        public async Task<IActionResult> AddToRole(RoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await service.AddToRole(model);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
