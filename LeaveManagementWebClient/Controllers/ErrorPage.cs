using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementWebClient.Controllers
{
    public class ErrorPage : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
