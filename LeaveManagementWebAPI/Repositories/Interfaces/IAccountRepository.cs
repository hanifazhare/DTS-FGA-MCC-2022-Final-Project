using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        User GetData(int id);

        ResponseLoginViewModel Login(LoginViewModel loginViewModel);

        int Register(RegisterViewModel registerViewModel);

        int ChangePassword(ChangePasswordViewModel changePasswordViewModel);

        int ForgotPassword(LoginViewModel loginViewModel);
    }
}
