using AutoMapper;
using BelajarASPNetMVC.Application.Helper;
using BelajarASPNetMVC.Application.Services.Users;
using BelajarASPNetMVC.Application.Services.Users.Dto;
using BelajarASPNetMVC.Data.Databases;
using BelajarASPNetMVC.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPNetMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private IUserAppService _userAppService;
        private IMapper _mapper;

        public UserController(IHttpContextAccessor context, IUserAppService userAppService, IMapper mapper)
        {
            _context = context;
            _userAppService = userAppService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var output = _userAppService.GetAll();

            return View(output);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var User = _userAppService.GetUserById(id);

            var model = _mapper.Map<UserViewModel>(User);

            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var model = new CreateUserViewModel();

            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = _mapper.Map<UserDto>(model);

                if (!UserHelper.IsValidEmail(newUser.Email))
                {
                    return Content("Invalid Email Format");
                }
                else
                {
                    _userAppService.Create(newUser);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserPass");
            var IsLogin = _context.HttpContext.Session.GetInt32("IsLogin");
            var IsAdmin = _context.HttpContext.Session.GetInt32("IsAdmin");

            if (Convert.ToInt16(IsLogin) == 0 && Convert.ToInt16(IsAdmin) == 0)
                return RedirectToAction("AccessDenied", "Account");

            var User = _userAppService.GetUserById(id);

            var model = _mapper.Map<EditUserViewModel>(User);

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editUser = _mapper.Map<UserDto>(model);

                _userAppService.Update(editUser);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
