using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DBContext _dbContext;

        public AccountRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        private static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

        public User GetData(int id)
        {
            return _dbContext.Users
                .Include(model => model.employee)
                .Include(model => model.userRoleType)
                .FirstOrDefault(model => model.id == id);
        }

        public ResponseLoginViewModel Login(LoginViewModel loginViewModel)
        {
            bool isPasswordCorrect = false;

            var data = _dbContext.Users
                .Include(model => model.employee)
                .Include(model => model.userRoleType)
                .FirstOrDefault(model => model.employee.email.Equals(loginViewModel.email));

            if (data != null)
            {
                isPasswordCorrect = ValidatePassword(loginViewModel.password, data.password);

                if (isPasswordCorrect)
                {
                    return new ResponseLoginViewModel()
                    {
                        id = data.id,
                        firstName = data.employee.firstName,
                        lastName = data.employee.lastName,
                        email = data.employee.email,
                        departmentTypeId = data.employee.departmentTypeId,
                        role = data.userRoleType.name
                    };
                }

                return null;
            }

            return null;
        }

        public int Register(RegisterViewModel registerViewModel)
        {
            int result = 0;

            var data = _dbContext.Users
                .Include(model => model.employee)
                .FirstOrDefault(model => model.employee.email.Equals(registerViewModel.email));

            if (data != null)
            {
                var user = new User
                {
                    id = data.employee.id,
                    password = HashPassword(registerViewModel.password)
                };
                _dbContext.Users.Add(user);
                int isNewUserSaved = _dbContext.SaveChanges();

                if (isNewUserSaved == 1)
                {
                    return result + 1;
                }

                return result;
            }

            return result;
        }

        public int ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            bool isPasswordCorrect = false;
            int result = 0;

            var data = _dbContext.Users
                .Include(model => model.employee)
                .FirstOrDefault(model => model.employee.email.Equals(changePasswordViewModel.email));

            if (data != null)
            {
                isPasswordCorrect = ValidatePassword(changePasswordViewModel.oldPassword, data.password);

                if (isPasswordCorrect)
                {
                    var newData = _dbContext.Users.Find(data.id);
                    newData.password = HashPassword(changePasswordViewModel.newPassword);
                    _dbContext.Users.Update(newData);
                    result = _dbContext.SaveChanges();

                    return result;
                }

                return result;
            }

            return result;
        }

        public int ForgotPassword(LoginViewModel loginViewModel)
        {
            int result = 0;

            var data = _dbContext.Users
                .Include(model => model.employee)
                .FirstOrDefault(model => model.employee.email.Equals(loginViewModel.email));

            if (data != null)
            {
                var newData = _dbContext.Users.Find(data.id);
                newData.password = HashPassword(loginViewModel.password);
                _dbContext.Users.Update(newData);
                result = _dbContext.SaveChanges();

                return result;
            }

            return result;
        }
    }
}
