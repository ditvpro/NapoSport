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
    public class CategoryController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                //create
                return View(new Category());
            }
            else
            {
                //update
                var categories = _unitOfWork.Category.Get(c => c.Id == id);
                return View(categories);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                TempData["success"] = "Thao tác thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        #region API CALLS
        public IActionResult GetAll()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = categories });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var categoryToDeleted = _unitOfWork.Category.Get(p => p.Id == id);

            if(categoryToDeleted == null)
            {
                return Json(new { success = false, message = "Không tìm brand để xóa" });
            }
            _unitOfWork.Category.Remove(categoryToDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Xóa thành công!" });
        }
        #endregion
    }
}
