using Microsoft.AspNetCore.Mvc;

namespace DailyNote.Controllers.Category
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
