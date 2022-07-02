using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Specialty.Controllers
{
    public class SpecialtyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
