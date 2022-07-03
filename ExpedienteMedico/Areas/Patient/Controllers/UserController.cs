using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Controllers
{

    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
