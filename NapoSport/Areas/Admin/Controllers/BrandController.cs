using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NapoSport.DataAccess.Data;
using NapoSport.DataAccess.Repository.IRepository;
using NapoSport.Models;
using NapoSport.Utility;

namespace NapoSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Brand.Add(brand);
                _unitOfWork.Save();
                TempData["success"] = "Thao tác thành công!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) return NotFound();
            Brand? brand = _unitOfWork.Brand.Get(b => b.Id == id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if(brand == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _unitOfWork.Brand.Update(brand);
                _unitOfWork.Save();
                TempData["success"] = "Thao tác thành công!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0) return NotFound();
            Brand? brand = _unitOfWork.Brand.Get(b => b.Id == id);
            if(brand == null) return NotFound();
            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Brand? brand = _unitOfWork.Brand.Get(b => b.Id == id);
            if(brand == null)
            {
                return NotFound();
            }
            _unitOfWork.Brand.Remove(brand);
            _unitOfWork.Save();
            TempData["success"] = "Thao tác thành công!";
            return RedirectToAction("Index");
        }
    }
}
