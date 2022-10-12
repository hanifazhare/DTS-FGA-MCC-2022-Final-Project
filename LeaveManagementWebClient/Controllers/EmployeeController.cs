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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        HttpClient HttpClient;

        [Route("Dashboard/EmployeeTab")]
        [HttpPost]
        public async Task<IActionResult> EmployeeTab(NewEmployeeViewModel newEmployeeViewModel)
        {
            string address = "https://localhost:44371/api/Employee/create";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            var departmentId = HttpContext.Session.GetString("DepartmentId");
            var managerId = HttpContext.Session.GetString("UserId");

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                id = 0,
                firstname = newEmployeeViewModel.firstname,
                lasttname = newEmployeeViewModel.lasttname,
                genderTypeId = newEmployeeViewModel.genderTypeId,
                email = newEmployeeViewModel.email,
                phoneNumber = newEmployeeViewModel.phoneNumber,
                departmentId = Convert.ToInt32(departmentId),
                managerId = Convert.ToInt32(managerId)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(employeeViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClientViewModel>(await result.Content.ReadAsStringAsync());
                return RedirectToAction("EmployeeTab", "Dashboard");
            }
            return RedirectToAction("Error404", "ErrorPage");
        }
    }
}
