using BelajarASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BelajarASPNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            _context.HttpContext.Session.SetString("UserProfile", "");
            _context.HttpContext.Session.SetString("UserPass", "");
            _context.HttpContext.Session.SetString("IsLogin", "");
            _context.HttpContext.Session.SetString("IsAdmin", "");

            if ((user != null) && (user != ""))
            {
                _context.HttpContext.Session.SetString("UserProfile", user);
                _context.HttpContext.Session.SetString("UserPass", pass);
                _context.HttpContext.Session.SetInt32("IsLogin", IsLogin.Value);
                _context.HttpContext.Session.SetInt32("IsAdmin", IsAdmin.Value);
            }
            else
            {
                _context.HttpContext.Session.SetString("UserProfile", "");
                _context.HttpContext.Session.SetString("UserPass", "");
                _context.HttpContext.Session.SetString("IsLogin", "");
                _context.HttpContext.Session.SetString("IsAdmin", "");
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}