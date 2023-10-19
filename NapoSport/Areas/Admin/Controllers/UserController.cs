using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NapoSport.DataAccess.Data;
using NapoSport.DataAccess.Repository;
using NapoSport.DataAccess.Repository.IRepository;
using NapoSport.Models;
using NapoSport.Models.ViewModels;
using NapoSport.Utility;

namespace NapoSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(string userId)
        {
            string roleId = _db.UserRoles.FirstOrDefault(r => r.UserId == userId).RoleId;

            UserVM userVM = new UserVM()
            {
                User = _db.ApplicationUser.Include(u => u.Company).FirstOrDefault(u => u.Id == userId),
                RoleList = _db.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }),
                CompanyList = _db.Companies.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            userVM.User.Role = _db.Roles.FirstOrDefault(u => u.Id == roleId).Name;

            return View(userVM);
            
        }

        [HttpPost]
        public IActionResult Edit(UserVM userVM)
        {
            string roleId = _db.UserRoles.FirstOrDefault(u => u.UserId == userVM.User.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == roleId).Name;

            if (!(userVM.User.Role == oldRole))
            {
                ApplicationUser applicationUser = _db.ApplicationUser.FirstOrDefault(u => u.Id == userVM.User.Id);
                if (userVM.User.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = userVM.User.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _db.SaveChanges();
                
                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, userVM.User.Role).GetAwaiter().GetResult();

            }
            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Không tìm thấy User để Khóa/Mở khóa" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddDays(7);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Thao tác thành công" });
        }
        #endregion
    }
}
