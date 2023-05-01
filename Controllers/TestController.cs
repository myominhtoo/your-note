using Microsoft.AspNetCore.Mvc;

namespace DailyNote.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
