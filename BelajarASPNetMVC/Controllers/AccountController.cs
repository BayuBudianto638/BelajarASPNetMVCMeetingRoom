using BelajarASPNetMVC.Application.Services.Users;
using BelajarASPNetMVC.Models.Logins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelajarASPNetMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _context;
        public readonly IUserAppService _userAppService;

        public AccountController(IHttpContextAccessor context, IUserAppService userAppService)
        {
            _context = context;
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginViewModel model)
        {
            //var model = new LoginViewModel();
            if (model.Email != null)
            {
                bool IsExist = _userAppService.IsUserExist(model.Email, model.Password);
                if (!IsExist)
                {
                    return RedirectToAction("AccessDenied", "Account");
                }
                else
                {
                    _context.HttpContext.Session.SetString("UserProfile", model.Email);
                    _context.HttpContext.Session.SetString("UserPass", model.Password);
                    _context.HttpContext.Session.SetInt32("IsLogin", 1);
                    _context.HttpContext.Session.SetInt32("IsAdmin", 1);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                model = new LoginViewModel();
            }

            return View(model);
        }

    }
}
