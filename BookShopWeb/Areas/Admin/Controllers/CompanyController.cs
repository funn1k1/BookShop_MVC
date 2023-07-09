using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var companies = _unitOfWork.Companies.GetAll();
            return View(companies);
        }

        public IActionResult Upsert(int? id)
        {
            if (id is null)
            {
                var newCompany = new Company();
                return View(newCompany);
            }

            var company = _unitOfWork.Companies.Get(c => c.Id == id);
            if (company is null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (!ModelState.IsValid)
            {
                var newCompany = new Company();
                return View(newCompany);
            }

            bool isNewCompany = company.Id == 0;

            if (isNewCompany)
            {
                _unitOfWork.Companies.Add(company);
            }
            else
            {
                _unitOfWork.Companies.Update(company);
            }

            _unitOfWork.Save();

            TempData["Success"] = isNewCompany ? "Company created successfully" : "Company edited successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var company = _unitOfWork.Companies.Get(b => b.Id == id);
            if (company is null)
            {
                return Json(new { success = false, message = "Error when deleting the company" });
            }

            _unitOfWork.Companies.Remove(company);
            _unitOfWork.Save();

            return Json(new { success = true, message = $"The company has been deleted" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _unitOfWork.Companies.GetAll();
            return Json(new { data = companies });
        }
    }
}
