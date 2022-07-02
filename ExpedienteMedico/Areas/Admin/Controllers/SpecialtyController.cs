using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Controllers
{

    [Area("Admin")]
    public class SpecialtyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
