using LeaveManagementWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace LeaveManagementWebClient.Controllers
{
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            string address = "https://localhost:5001/api/Account/Login";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientViewModel>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.role);
                HttpContext.Session.SetString("UserId", Convert.ToString(data.Data.id) );
                HttpContext.Session.SetString("DepartmentId", Convert.ToString(data.Data.departmentTypeId));
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public IActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrasi(AccountViewModel accountViewModel)
        {
            string address = "https://localhost:5001/api/Account/Register";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(accountViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientViewModel>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPass(AccountViewModel accountViewModel)
        {
            string address = "https://localhost:5001/api/Account/forgotPass";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(accountViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientViewModel>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePasswordViewModel changePasswordViewModel)
        {
            string address = "https://localhost:5001/api/Account/changePass";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientViewModel>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }
    }
}
