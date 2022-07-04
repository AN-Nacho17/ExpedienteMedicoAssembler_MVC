
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Controllers
{

    [Area("Patient")]
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.User.GetAll();
            return Json(new { data = users, success = true });
        }

        #endregion
    }
}
