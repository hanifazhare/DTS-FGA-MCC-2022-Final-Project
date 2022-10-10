using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Datas;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("user/{id}")]
        [HttpPost]
        public ActionResult GetDataService(int id)
        {
            var data = _accountRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("login")]
        [HttpPost]
        public ActionResult LoginService(LoginViewModel loginViewModel)
        {
            var data = _accountRepository.Login(loginViewModel);
            if (data != null)
                return Ok(new { statusCode = 200, data = data });

            return BadRequest(new { statusCode = 400, data = "null" });
        }

        [Route("register")]
        [HttpPost]
        public ActionResult RegisterService(RegisterViewModel registerViewModel)
        {
            var data = _accountRepository.Register(registerViewModel);
            if (data == 1)
                return Ok(new { statusCode = 200, message = "Success register user" });

            return BadRequest(new { statusCode = 400, message = "Failed register user" });
        }

        [Route("change-password")]
        [HttpPost]
        public ActionResult ChangePasswordService(ChangePasswordViewModel changePasswordViewModel)
        {
            var data = _accountRepository.ChangePassword(changePasswordViewModel);
            if (data == 1)
                return Ok(new { statusCode = 200, message = "Success change user password" });

            return BadRequest(new { statusCode = 400, message = "Failed change user password" });
        }

        [Route("forgot-password")]
        [HttpPost]
        public ActionResult ForgotPasswordService(LoginViewModel loginViewModel)
        {
            var data = _accountRepository.ForgotPassword(loginViewModel);
            if (data == 1)
                return Ok(new { statusCode = 200, message = "Success change user password" });

            return BadRequest(new { statusCode = 400, message = "Failed change user password" });
        }
    }
}
