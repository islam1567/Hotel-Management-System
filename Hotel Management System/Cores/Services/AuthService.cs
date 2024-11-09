using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotel_Management_System.Cores.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly RoleManager<IdentityRole> rolemanager;

        public AuthService(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            this.usermanager = usermanager;
            this.rolemanager = rolemanager;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if(await usermanager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email Is Exist" };

            var user = new ApplicationUser()
            {
                //FirstName = model.FirstName,
                //LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,              
            };

            var result = await usermanager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new AuthModel { Message = "Error" };

            var jwtsecuritykey = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtsecuritykey),
                ExpireOn = jwtsecuritykey.ValidTo,
                IsAuthantication = true,               
            };
        }
        public async Task<AuthModel> GetTokenAsync(LoginModel model)
        {
            var user = await usermanager.FindByEmailAsync(model.Email);
            if (user is null || !await usermanager.CheckPasswordAsync(user, model.Password))
                return new AuthModel { Message = "Email Or Password Is Incorrect" };

            var jwtsecuritykey = await CreateToken(user);
            return new AuthModel
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtsecuritykey),
                ExpireOn = jwtsecuritykey.ValidTo,
                IsAuthantication = true,
            };
        }

        public async Task<string> AddToRole(RoleModel model)
        {
            var user = await usermanager.FindByIdAsync(model.UserId);
            if (user is null || !await rolemanager.RoleExistsAsync(model.Role))
                return "Invalid Role Or UserId";

            if (await usermanager.IsInRoleAsync(user, model.Role))
                return "User Already In This Role";

            var result = await usermanager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something Is Wronge";

        }

        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var roles = await usermanager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securitykey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes("HForjfjfjFDEprpkSSSoHJKFFFFFFFFFFDRYUYULOIIHGSGSIUSGhhvhkuUTTYIDRSEZSERJHPGFEYHHLJKJHFHGDLIooHH"));

            var signingcredentials = new SigningCredentials
                (securitykey, SecurityAlgorithms.HmacSha256);


            var jwtsecuritytoken = new JwtSecurityToken(
                issuer: "https://localhost:44348/",
                audience: "https://localhost:4200/",
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: signingcredentials
                );

            return jwtsecuritytoken;    
        }

        public async Task<bool> ChangePassword(string UserId, ChangePasswordRequest request)
        {
            var user = await usermanager.FindByIdAsync(UserId);
            if(user == null)
            {
                return false;
            }
            var checkpassword = await usermanager.CheckPasswordAsync(user, request.CurrentPassword);
            if(!checkpassword)
            {
                return false;
            }
            var result = await usermanager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            return result.Succeeded;
        }
    }
}
