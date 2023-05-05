using DailyNote.Models.Constants;
using DailyNote.Models.Entities;
using DailyNote.Models.ViewModels.Request;
using DailyNote.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace DailyNote.Controllers.User
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController( IUserService userService )
        {
            _userService = userService;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginRequestViewModel model = new();
            return View(model);
        }


        [HttpPost]
        public IActionResult Login( LoginRequestViewModel model )
        {
            if (!ModelState.IsValid)
                return View(model);

            UserEntity? userEntity = _userService.GetUserByEmail(model.Email);

            if( userEntity == null || !model.Password.Equals(userEntity?.Password))
            {
                ModelState.AddModelError("Email", Messages.INVALID_LOGIN );
                ModelState.AddModelError("Password", Messages.INVALID_LOGIN);
                return View(model);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,model.Email)
            } , CookieAuthenticationDefaults.AuthenticationScheme );

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principal );

            TempData["message"] = Messages.LOGIN_SUCCESS;

            return RedirectToAction(nameof(Home));
        }

        public IActionResult Register()
        {
            RegisterRequestViewModel model = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register( RegisterRequestViewModel model )
        {
            if(!ModelState.IsValid) 
            {
                return View(model);
            }

            if (_userService.IsDuplicateEmail(model.Email))
            {
                ModelState.AddModelError("Email", Messages.DUPLICATE_USER);
                return View(model);
            }

            TempData["message"] = _userService.CreateUser(model);

            return RedirectToAction(nameof(Login));
        }

    }
}
