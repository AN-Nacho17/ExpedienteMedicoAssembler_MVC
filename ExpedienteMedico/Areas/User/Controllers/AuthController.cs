using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.User.Controllers
{
    [Route("User/[controller]")]
    [ApiController]
    [EnableCors("GeneralPolicy")]
    public class AuthController : Controller
    {

        private readonly IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public AuthController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        //API 

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            IdentityUser user = _userManager.FindByEmailAsync(email).Result;
            if (user != null && _userManager.CheckPasswordAsync(user, password).Result)
            {
                return Json(new { data = user.Id, success = true });
            }
            else
            {
                return Json(new { data = "No se pudo encontrar el usuario", success = false });
            }
        }


    }
}
