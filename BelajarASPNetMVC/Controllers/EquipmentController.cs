using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Application.Services.Equipments;
using BelajarASPNetMVC.Application.Services.Equipments.Dto;
using BelajarASPNetMVC.Models.Beverages;
using BelajarASPNetMVC.Models.Equipments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPNetMVC.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentAppService _equipmentAppService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        public EquipmentController(IEquipmentAppService equipmentAppService, IMapper mapper, IHttpContextAccessor context)
        {
            _equipmentAppService = equipmentAppService;
            _mapper = mapper;
            _context = context;
        }

        // GET: EquipmentController
        public ActionResult Index()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var equipment = _equipmentAppService.GetEquipment();
            var model = _mapper.Map<List<EquipmentViewModel>>(equipment);

            return View(model);
        }

        // GET: EquipmentController/Details/5
        public ActionResult Details(int id)
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var equipment = _equipmentAppService.GetById(id);
            var model = _mapper.Map<EquipmentViewModel>(equipment);

            return View(model);
        }

        // GET: EquipmentController/Create
        public ActionResult Create()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var model = new CreateEquipmentViewModel();

            return View(model);
        }

        // POST: EquipmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEquipmentViewModel model)
        {
            try
            {
                var newBeverage = _mapper.Map<EquipmentDto>(model);
                _equipmentAppService.Create(newBeverage);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var equipment = _equipmentAppService.GetById(id);
            var editEquipment = _mapper.Map<EditEquipmentViewModel>(equipment);
            return View(editEquipment);
        }

        // POST: EquipmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditEquipmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editEquipment = _mapper.Map<EquipmentDto>(model);
                    _equipmentAppService.Update(editEquipment);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var equipment = _equipmentAppService.GetById(id);
            var model = _mapper.Map<EditEquipmentViewModel>(equipment);
            return View(model);
        }

        // POST: EquipmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditEquipmentViewModel model)
        {
            try
            {
                _equipmentAppService.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
