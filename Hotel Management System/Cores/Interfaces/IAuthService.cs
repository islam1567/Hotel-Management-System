using Hotel_Management_System.Cores.Dtos;

namespace Hotel_Management_System.Cores.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(LoginModel model);
        Task<string> AddToRole(RoleModel model);
        Task<bool> ChangePassword(string UserId, ChangePasswordRequest request);
    }
}
