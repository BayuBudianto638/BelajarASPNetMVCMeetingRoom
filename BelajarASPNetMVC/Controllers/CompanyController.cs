using BelajarASPNetMVC.Application.Services.Companies;
using BelajarASPNetMVC.Application.Services.Companies.Dto;
using BelajarASPNetMVC.Models.Companies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelajarASPNetMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }
        public IActionResult Index()
        {
            var data = _companyAppService.GetCompanies();

            var output = new List<CompanyModel>();
            foreach(var item in data)
            {
                var dataOutput = new CompanyModel();

                dataOutput.Id = item.Id;
                dataOutput.Name = item.Name;
                dataOutput.Address = item.Address;
                dataOutput.Country = item.Country;

                output.Add(dataOutput);
            }

            return View(output);
        }

        public IActionResult Details(int Id)
        {
            var company = _companyAppService.GetById(Id);

            var model = new CompanyModel()
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country
            };

            return View(model);
        }

        // View Model Create
        public IActionResult Create()
        {
            var model = new CreateCompanyViewModel();

            List<int> last10Years = new List<int>();
            int currentYear = DateTime.Now.Year;

            for (int i = currentYear; i < currentYear + 10; i++)
            {
                last10Years.Add(i);
            }

            ViewBag.LastTenYears = new SelectList(last10Years);

            return View(model);
        }

        // HTTP Method View Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCompany = new CompanyDto()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Country = model.Country
                };

                _companyAppService.Create(newCompany);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var company = _companyAppService.GetById(Id);

            var model = new EditCompanyViewModel()
            {
                Name = company.Name,
                Address = company.Address,
                Country = company.Country
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditCompanyViewModel model)
        {
            if(ModelState.IsValid)
            {
                var editCompany = new CompanyDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    Country = model.Country
                };

                _companyAppService.Update(editCompany);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            var company = _companyAppService.GetById(Id);
            var editCompanyViewModel = new EditCompanyViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country
            };

            return View(editCompanyViewModel);

            //try
            //{
            //    _companyAppService.Delete(Id);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
        }

        [HttpPost]
        public IActionResult Delete(EditCompanyViewModel model)
        {
            try
            {
                _companyAppService.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
