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
        public IActionResult Login(LoginViewModel login)
        {
            var emailHere = login.Email;
            var passHere = login.Password;
            if (emailHere.Equals("admin@email.com") && passHere.Equals("admin"))
            {
                HttpContext.Session.SetString("Role", "Manager");
                return RedirectToAction("Index", "Dashboard");

            } else if (emailHere.Equals("admin2@email.com") && passHere.Equals("admin2"))
            {
                HttpContext.Session.SetString("Role", "Karyawan");
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
