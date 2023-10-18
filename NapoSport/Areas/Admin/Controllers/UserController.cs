using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NapoSport.DataAccess.Data;
using NapoSport.DataAccess.Repository.IRepository;
using NapoSport.Models;
using NapoSport.Utility;

namespace NapoSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> userList = _db.ApplicationUser.Include(u => u.Company).ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in userList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company() { Name = "" };
                }
            }

            return Json(new {data = userList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = true, message = "Xóa thành công!" });
        }
        #endregion
    }
}
