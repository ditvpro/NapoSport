using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NapoSport.DataAccess.Data;
using NapoSport.DataAccess.Repository.IRepository;
using NapoSport.Models;
using NapoSport.Utility;
using System.Drawing.Drawing2D;

namespace NapoSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Brand> brands = _unitOfWork.Brand.GetAll().ToList();
            return View(brands);
        }
        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                //create
                return View(new Brand());
            }
            else
            {
                //update
                var brand = _unitOfWork.Brand.Get(c => c.Id == id);
                return View(brand);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Brand brand)
        {
            if(ModelState.IsValid)
            {
                if(brand.Id == 0)
                {
                    _unitOfWork.Brand.Add(brand);
                }
                else
                {
                    _unitOfWork.Brand.Update(brand);
                }
                _unitOfWork.Save();
                TempData["success"] = "Thao tác thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(brand);
            }
        }

        #region API CALLS
        public IActionResult GetAll()
        {
            List<Brand> brands = _unitOfWork.Brand.GetAll().ToList();
            return Json(new { data = brands });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var brandToDeleted = _unitOfWork.Brand.Get(p => p.Id == id);

            if(brandToDeleted == null)
            {
                return Json(new { success = false, message = "Không tìm brand để xóa" });
            }
            _unitOfWork.Brand.Remove(brandToDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Xóa thành công!" });
        }
        #endregion
    }
}
