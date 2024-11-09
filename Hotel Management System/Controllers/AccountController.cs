using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Cores.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService service;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly IEmailSender emailsender;

        public AccountController(IAuthService service, UserManager<ApplicationUser> usermanager, IEmailSender emailsender)
        {
            this.service = service;
            this.usermanager = usermanager;
            this.emailsender = emailsender;
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

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await service.ChangePassword(userid, request);
            if(success)
            {
                return Ok("Password Changed Successfully");
            }
            return BadRequest("Failed Change Password");
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgerPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Please Enter Your Email");
            }
            var user = await usermanager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Ok("if email is found, you can reset password");
            }

            var token = await usermanager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = token }, Request.Scheme);
            await emailsender.SendEmailAsync(request.Email, "Please reset password", $"Link Is {resetLink}");

            return Ok("Password reset link has been send to your email");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string userId, string Code, string newPassword)
        {
            var user = await usermanager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("User is not found");
            }
            var result = await usermanager.ResetPasswordAsync(user, Code, newPassword);
            if (result.Succeeded)
            {
                return Ok("Password has ben updated successfully");
            }
            return BadRequest("failed to update password");
        }

        [HttpGet("login-facebook")]
        public IActionResult LoginWithFaceBook(string returnUrl="/")
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("FacebookResponse", new { returnUrl })
            };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("login-facebook-response")]
        public async Task<IActionResult> FaceBookResponse(string returnurl="/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if(!result.Succeeded)
            {
                return BadRequest();
            }
            return LocalRedirect(returnurl);
        }


        [HttpGet("login-google")]
        public IActionResult LoginWithGoogle(string returnUrl="/")
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse", new { returnUrl })
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("login-google-response")]
        public async Task<IActionResult> GoogleResponse(string returnUrl="/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if(! result.Succeeded)
            {
                return BadRequest();
            }
            return LocalRedirect(returnUrl);
        }
        
    }
}
