
using ExpedienteMedico.Data;
using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpedienteMedico.Controllers
{

    [Area("Patient")]
    public class UserController : Controller
    {
        private IUnitOfWork _db;

        public UserController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
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

            var user = _db.User.GetFirstOrDefault(x => x.Id == id);
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
        public IActionResult Delete(string? id)
        {
            var obj = _db.User.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
                return NotFound();

            _db.User.Remove(obj);
            _db.Save();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
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
