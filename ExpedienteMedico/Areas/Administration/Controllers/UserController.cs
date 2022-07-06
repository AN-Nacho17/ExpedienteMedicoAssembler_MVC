using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Administration.Controllers
{

    [Area("Administration")]
    public class UserController : Controller
    {
        private IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _db.User.GetAll();
            return View(users);
        }

        //GET ********************************
        public IActionResult Edit(string? id)   //Update + Insert
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _db.User.GetFirstOrDefault(x => x.Id == id, null);
            //var categoryFromDb = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //POST **********************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.Save();
                TempData["success"] = "User Updated successfully";
            }
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        public IActionResult Banned(string? id)
        {
            if (id != null)
            {
                _userManager.SetLockoutEnabledAsync(_db.User.GetFirstOrDefault(x => x.Id == id, null), true);
                _userManager.SetLockoutEndDateAsync(_db.User.GetFirstOrDefault(x => x.Id == id, null), DateTimeOffset.MaxValue);
            }
            _db.Save();
            return Json(new { success = true, message = "Banned Successfully" });
        }

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _db.User.GetAll();
            return Json(new { data = users, success = true });
        }

        #endregion
    }
}
