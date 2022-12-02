using AutoMapper;
using BelajarASPNetMVC.Application.Services.Layouts.Dto;
using BelajarASPNetMVC.Application.Services.Rooms;
using BelajarASPNetMVC.Application.Services.Rooms.Dto;
using BelajarASPNetMVC.Data.Databases;
using BelajarASPNetMVC.Models.Layouts;
using BelajarASPNetMVC.Models.Rooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPNetMVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomAppService _roomAppService;
        private readonly IMapper _mapper;

        public RoomController(IRoomAppService roomAppService, IMapper mapper)
        {
            _roomAppService = roomAppService;
            _mapper = mapper;
        }

        public ActionResult RoomList()
        {
            return PartialView();
        }

        public FileContentResult GetFile(int id)
        {
            Room mediaImage = _roomAppService.GetById(id);
            return new FileContentResult(mediaImage.Image, "image/*");
        }

        // GET: RoomController
        public ActionResult Index()
        {
            var rooms = _roomAppService.GetAllRoom();
            var model = _mapper.Map<List<RoomViewModel>>(rooms);

            return View(model);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            var room = _roomAppService.GetById(id);
            var model = _mapper.Map<RoomViewModel>(room);

            ViewBag.Base64String = "data:image/png;base64," + 
                Convert.ToBase64String(model.Image, 0, model.Image.Length);

            return View(model);
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            var model = new CreateRoomViewModel();

            return View(model);
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoomViewModel model)
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

                var newRoom = _mapper.Map<RoomDto>(model);
                newRoom.Image = rawBytes;
                newRoom.FilePath = "";

                _roomAppService.Create(newRoom);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            var room = _roomAppService.GetById(id);
            var model = _mapper.Map<EditRoomViewModel>(room);

            ViewBag.Base64String = "data:image/png;base64," + 
                Convert.ToBase64String(model.Image, 0, model.Image.Length);

            return View(model);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditRoomViewModel model)
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

                    var editRoom = _mapper.Map<RoomDto>(model);
                    editRoom.Image = rawBytes;
                    editRoom.FilePath = "";

                    _roomAppService.Update(editRoom);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        public JsonResult GetRoom(int id)
        {
            var roomList = _roomAppService.GetRoom(id);
            return Json(roomList);
        }

        public JsonResult GetAllRoom()
        {
            var roomList = _roomAppService.GetAllRoom();
            return Json(roomList);
        }


        //public JsonResult GetRoomById(int id)
        //{
        //    var roomList = _roomAppService.GetLayoutImageByRoomId(id);
        //    return Json(roomList);
        //}
    }
}
