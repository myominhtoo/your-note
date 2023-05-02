using Microsoft.AspNetCore.Mvc;

namespace DailyNote.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
