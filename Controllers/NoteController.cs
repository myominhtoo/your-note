using Microsoft.AspNetCore.Mvc;

namespace DailyNote.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
