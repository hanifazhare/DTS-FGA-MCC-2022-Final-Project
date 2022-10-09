using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementWebClient.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
