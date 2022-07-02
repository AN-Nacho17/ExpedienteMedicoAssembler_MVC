using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Controllers
{

    [Area("Physician")]
    public class PhysicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
