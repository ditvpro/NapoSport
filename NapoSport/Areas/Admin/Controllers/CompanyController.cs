using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NapoSport.DataAccess.Repository.IRepository;
using NapoSport.Models;
using NapoSport.Utility;

namespace NapoSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return View(companies);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                var company = _unitOfWork.Company.Get(c => c.Id == id);
                return View(company);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                TempData["success"] = "Thao tác thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
            }
        }

        #region API CALLS
        public IActionResult GetAll()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = companies});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToDeleted = _unitOfWork.Company.Get(p => p.Id == id);

            if(companyToDeleted == null)
            {
                return Json(new { success = false, message = "Không tìm thấy sản phẩm để xóa" });
            }
            _unitOfWork.Company.Remove(companyToDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Xóa thành công!" });
        }
        #endregion
    }
}
