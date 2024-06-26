using Microsoft.AspNetCore.Mvc;
using secondogiorno.Services;
using secondogiorno3.Models;
using System.Diagnostics;

namespace secondogiorno3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICVService _cvService;

        public HomeController(ILogger<HomeController> logger,ICVService service)
        {
            _logger = logger;
            _cvService = service;
        }

        public IActionResult Index()
        {
            var cv = _cvService.CreaCV();
            return View(cv);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult info()
        {
            _cvService.AggiungereInfopersonali(new secondogiorno.personalInfo
            {
                Phone = 33773535,
                Email = "fnrr@debf",
                Name = "Fra",
                SurName = "Gia"
            });
            return RedirectToAction("Index");
        }
        public IActionResult Study() {
            _cvService.AggiungereTitolostudio(
                new secondogiorno.TitoloDiStudio { 
                Al = new DateOnly(2000, 1, 1),
            Dal = new DateOnly(1995, 1, 1),
            Istituto = "Università",
            Qualifica = "Laurea",
            Tipo = "Scuola"
               } );

            _cvService.AggiungereTitolostudio(new secondogiorno.TitoloDiStudio
            {
                Al = new DateOnly(1999, 1, 1),
                Dal = new DateOnly(1997, 1, 1),
                Istituto = "Istituto superiore",
                Qualifica = "Diploma",
                Tipo = "Scuola"
            });
            return RedirectToAction("Index");
        }
        public IActionResult Exp() {
            _cvService.AggiungereEsperienza(new secondogiorno.Esperienza
            {
                Al = DateOnly.FromDateTime(DateTime.Now),
                Dal = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                Azienda = "Privata",
                Compiti = "tuttofare",
                Descrizione = "ero un tuttofare",
                JobTitle = "tuttofare"

            });
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
