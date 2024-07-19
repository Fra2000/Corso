using Microsoft.AspNetCore.Mvc;

namespace quintogiorno.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Anagrafica()
        {
            return RedirectToAction("Index", "Anagrafica");
        }

        public IActionResult TipoViolazione()
        {
            return RedirectToAction("Index", "TipoViolazione");
        }

        public IActionResult Verbale()
        {
            return RedirectToAction("Index", "Verbale");
        }
    }
}
