using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages;
using BelajarASPNetMVC.Application.Services.Beverages.Dto;
using BelajarASPNetMVC.Models.Beverages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPNetMVC.Controllers
{
    public class BeverageController : Controller
    {
        private readonly IBeverageAppService _beverageAppService;
        private readonly IMapper _mapper;
        public BeverageController(IBeverageAppService beverageAppService, IMapper mapper)
        {
            _beverageAppService = beverageAppService;
            _mapper = mapper;
        }

        // GET: BeverageController
        public ActionResult Index()
        {
            var beverages = _beverageAppService.GetBeverage();
            var model = _mapper.Map<List<BeverageViewModel>>(beverages);
            
            return View(model);
        }

        // GET: BeverageController/Details/5
        public ActionResult Details(int id)
        {
            var beverage = _beverageAppService.GetById(id);
            var model = _mapper.Map<BeverageViewModel>(beverage);

            return View(model);
        }

        // GET: BeverageController/Create
        public ActionResult Create()
        {
            var model = new CreateBeverageViewModel();

            return View(model);
        }

        // POST: BeverageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBeverageViewModel model)
        {
            try
            {
                var newBeverage = _mapper.Map<BeverageDto>(model);
                _beverageAppService.Create(newBeverage);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeverageController/Edit/5
        public ActionResult Edit(int id)
        {
            var beverage = _beverageAppService.GetById(id);
            var editBeverage = _mapper.Map<EditBeverageViewModel>(beverage);
            return View(editBeverage);
        }

        // POST: BeverageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditBeverageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editBeverage = _mapper.Map<BeverageDto>(model);
                    _beverageAppService.Update(editBeverage);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeverageController/Delete/5
        public ActionResult Delete(int id)
        {
            var beverage = _beverageAppService.GetById(id);
            var model = _mapper.Map<EditBeverageViewModel>(beverage);
            return View(model);
        }

        // POST: BeverageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditBeverageViewModel model)
        {
            try
            {
                _beverageAppService.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
