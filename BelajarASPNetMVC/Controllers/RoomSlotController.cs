using BelajarASPNetMVC.Application.Services.RoomSlots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using BelajarASPNetMVC.Models.RoomSlots;

namespace BelajarASPNetMVC.Controllers
{
    public class RoomSlotController : Controller
    {
        private readonly IRoomSlotAppService _roomSlotAppService;
        private readonly IMapper _mapper;
        public RoomSlotController(IRoomSlotAppService roomSlotAppService, IMapper mapper)
        {
            _roomSlotAppService = roomSlotAppService;
            _mapper = mapper;
        }

        // GET: RoomSlotController
        public ActionResult Index()
        {
            var output = _roomSlotAppService.GetAll();

            List<int> last10Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear; i < currentYear + 10; i++)
            {
                last10Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last10Years);

            var model = _mapper.Map<List<CreateRoomSlotViewModel>>(output);

            return View(model);
        }

        // GET: RoomSlotController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomSlotController/Create
        public ActionResult Create()
        {
            var model = new CreateRoomSlotViewModel();

            List<int> last10Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear; i < currentYear + 10; i++)
            {
                last10Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last10Years);

            return View(model);
        }

        // POST: RoomSlotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomSlotViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _roomSlotAppService.GenerateRoomSlot(model.startMonth, model.endMonth, model.year, model.roomId);

                if (isSuccess == false)
                {
                    List<int> last10Years = new List<int>();
                    int currentYear = DateTime.Now.Year;

                    for (int i = currentYear; i < currentYear + 10; i++)
                    {
                        last10Years.Add(i);
                    }

                    ViewBag.LastTenYears = new SelectList(last10Years);

                    ViewBag.MyErrorMessage = "Failed Generate Room Slot. Room Slot already exist!";
                    return View();
                }
                else
                {

                    List<int> last10Years = new List<int>();
                    int currentYear = DateTime.Now.Year;

                    for (int i = currentYear; i < currentYear + 10; i++)
                    {
                        last10Years.Add(i);
                    }

                    ViewBag.LastTenYears = new SelectList(last10Years);

                    ViewBag.MyErrorMessage = "Success Generate Room Slot!";
                    return View();
                }
            }

            return View(model);
        }

        // GET: RoomSlotController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomSlotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomSlotController/Delete/5
        public ActionResult Delete(int id)
        {
            List<int> last10Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear; i < currentYear + 10; i++)
            {
                last10Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last10Years);

            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        public JsonResult DeleteData(string month, string year, string day, string roomId)
        {
            try
            {
                // TODO: Add delete logic here
                _roomSlotAppService.Delete(month, year, day, roomId);
                //return RedirectToAction("Index");
                return Json("Success");
            }
            catch
            {
                //return View();
                return Json("Gagal");
            }
        }

        public ActionResult Filter()
        {
            var model = new CreateRoomSlotViewModel();

            List<int> last10Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear; i < currentYear + 10; i++)
            {
                last10Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last10Years);

            return View(model);
        }

        public JsonResult GetRoomSlot(int? month, int? year, int? roomId)
        {
            var roomSlotList = _roomSlotAppService.GetFilter(month, year, roomId);
            return Json(roomSlotList);
        }

        public JsonResult GetWebConfigHome()
        {
            var configServer = System.Configuration.ConfigurationManager.AppSettings["ServerHome"].ToString();
            return Json(configServer);
        }

        [HttpPost]
        public JsonResult DeleteById(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _roomSlotAppService.DeleteById(id);
                //return RedirectToAction("Index");
                return Json("Success");
            }
            catch
            {
                //return View();
                return Json("Gagal");
            }
        }
    }
}
