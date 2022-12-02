using AutoMapper;
using BelajarASPNetMVC.Application.Services.Layouts;
using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Data.Databases;
using BelajarASPNetMVC.Models.Equipments;
using BelajarASPNetMVC.Models.Layouts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BelajarASPNetMVC.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ILayoutAppService _layoutAppService;
        private readonly IMapper _mapper;
        public LayoutController(ILayoutAppService layoutAppService, IMapper mapper)
        {
            _layoutAppService = layoutAppService;
            _mapper = mapper;
        }

        public ActionResult LayoutList()
        {
            var output = _layoutAppService.GetLayout();
            return PartialView(output);
        }

        public FileContentResult GetFile(int id)
        {
            Layout mediaImage = _layoutAppService.GetById(id);
            return new FileContentResult(mediaImage.LayoutImages, "image/*");
        }

        // GET: LayoutController
        public ActionResult Index()
        {
            var layouts = _layoutAppService.GetLayout();
            var model = _mapper.Map<List<LayoutViewModel>>(layouts);

            return View(model);
        }

        // GET: LayoutController/Details/5
        public ActionResult Details(int id)
        {
            var layout = _layoutAppService.GetById(id);

            var model = _mapper.Map<LayoutViewModel>(layout);
            if (model.LayoutImages != null)
            {
                ViewBag.Base64String = "data:image/png;base64," +
                    Convert.ToBase64String(model.LayoutImages, 0, model.LayoutImages.Length);
            }

            return View(model);
        }

        // GET: LayoutController/Create
        public ActionResult Create()
        {
            var model = new CreateLayoutViewModel();

            return View(model);
        }

        // POST: LayoutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLayoutViewModel model)
        {
            try
            {
                byte[] rawBytes = null;
                if (Request.Form.Files.Count > 0)
                {
                    var inputFile = Request.Form.Files[0];
                    var fileNm = Request.Form.Files[0].FileName;
                    Stream fileStream = inputFile.OpenReadStream();
                    rawBytes = new byte[fileStream.Length];
                    fileStream.Read(rawBytes, 0, Convert.ToInt32(fileStream.Length));
                }

                var newLayout = _mapper.Map<LayoutDto>(model);
                newLayout.LayoutImages = rawBytes;
                newLayout.LayoutFilePath = "";

                _layoutAppService.Create(newLayout);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LayoutController/Edit/5
        public ActionResult Edit(int id)
        {
            var layout = _layoutAppService.GetById(id);
            var model = _mapper.Map<EditLayoutViewModel>(layout);
            
            if (model.LayoutImages != null)
            {
                ViewBag.Base64String = "data:image/png;base64," + 
                    Convert.ToBase64String(model.LayoutImages, 0, 
                    model.LayoutImages.Length);
            }

            return View(model);
        }

        // POST: LayoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditLayoutViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] rawBytes = null;
                    if (Request.Form.Files.Count > 0)
                    {
                        var inputFile = Request.Form.Files[0];
                        var fileNm = Request.Form.Files[0].FileName;
                        Stream fileStream = inputFile.OpenReadStream();
                        rawBytes = new byte[fileStream.Length];
                        fileStream.Read(rawBytes, 0, Convert.ToInt32(fileStream.Length));
                    }

                    var editLayout = _mapper.Map<LayoutDto>(model);
                    editLayout.LayoutImages = rawBytes; // save ke db (Bad Idea)
                    editLayout.LayoutFilePath = "";

                    _layoutAppService.Update(editLayout);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LayoutController/Delete/5
        public ActionResult Delete(int id)
        {
            var layout = _layoutAppService.GetById(id);
            var model = _mapper.Map<EditLayoutViewModel>(layout);

            if (model.LayoutImages != null)
            {
                ViewBag.Base64String = "data:image/png;base64," + 
                    Convert.ToBase64String(model.LayoutImages, 0, model.LayoutImages.Length);
            }

            return View(model);
        }

        // POST: LayoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditLayoutViewModel model)
        {
            try
            {
                _layoutAppService.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetLayoutCapacity(int id)
        {
            var layoutList = _layoutAppService.GetCapacity(id);
            return Json(layoutList);
        }

        [HttpGet]
        public JsonResult GetLayout()
        {
            var layoutList = _layoutAppService.GetLayoutImage();
            return Json(layoutList);
        }

        [HttpGet]
        public JsonResult GetLayoutById(int id)
        {
            var layoutList = _layoutAppService.GetLayoutImageById(id);
            return Json(layoutList);
        }

        [HttpGet]
        public JsonResult GetAllLayout()
        {
            var layoutList = _layoutAppService.GetLayout();
            return Json(layoutList);
        }

        [HttpGet]
        public JsonResult GetPriceLayout(int Id)
        {
            var layoutList = _layoutAppService.GetPriceLayout(Id);
            return Json(layoutList);
        }
    }
}
