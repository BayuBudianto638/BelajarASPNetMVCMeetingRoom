using Microsoft.AspNetCore.Mvc;

namespace BelajarASPNetMVC.Controllers
{
    public class BookingListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
