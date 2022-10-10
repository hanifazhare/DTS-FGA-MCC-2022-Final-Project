using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        ResponseLoginViewModel Login(LoginViewModel loginViewModel);

        int Register(RegisterViewModel registerViewModel);

        int ChangePassword(ChangePasswordViewModel changePasswordViewModel);

        int ForgotPassword(LoginViewModel loginViewModel);
    }
}
