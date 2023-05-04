using Microsoft.AspNetCore.Mvc;

namespace DailyNote.Controllers.Note
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
