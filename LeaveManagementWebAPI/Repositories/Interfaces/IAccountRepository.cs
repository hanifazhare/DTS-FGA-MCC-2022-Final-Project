using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        ResponseLoginViewModel login(LoginViewModel loginViewModel);

        int register(RegisterViewModel registerViewModel);

        int changePassword(ChangePasswordViewModel changePasswordViewModel);

        int forgotPassword(LoginViewModel loginViewModel);
    }
}
