using DailyNote.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DailyNote.Filters
{
    public class AuthFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Nothing to override
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!Routes.PUBLIC_ROUTES.ToList().Contains(context.HttpContext.Request.Path) &&
                context.HttpContext.User.Identity?.Name == null)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
                
        }
    }
}
