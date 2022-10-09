using LeaveManagementWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementWebClient.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewLeaveReq() 
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {
                return RedirectToAction("Error404", "ErrorPage");
            }
            return View();
        }

        [HttpPost]
        public IActionResult NewLeaveReq(LeaveRequest leaveRequest)
        {
            //Ubah lagi isinya
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {

                return RedirectToAction("Error404", "ErrorPage");
            }
            return View();
        }

        public IActionResult LeaveUserTable() {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {
                return RedirectToAction("Error404", "ErrorPage");
            }
            return View();
        }

        public IActionResult LeaveReq() {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {
                return View();
            }
            return RedirectToAction("Error404", "ErrorPage");
        }

        public IActionResult LeaveType()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {
                return View();
            }
            return RedirectToAction("Error404", "ErrorPage");
        }

        public IActionResult EmployeeTab()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Manager"))
            {
                return View();
            }
            return RedirectToAction("Error404", "ErrorPage");
        }
    }
}
