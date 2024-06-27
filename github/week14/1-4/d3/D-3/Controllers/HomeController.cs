using D_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;


namespace D_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// /////////////////////////////////////////////////////////////


       

        [HttpGet]
      
        public IActionResult Vendi()
        {
            return View(new Biglietto());
        }

        [HttpPost]
        public IActionResult Vendi(Biglietto biglietto)
        {
            if (ModelState.IsValid)
            {
                var sala = CinemaData.Sale.FirstOrDefault(s => s.Nome == biglietto.Sala);
                if (sala != null)
                {
                    if (sala.BigliettiTotali < sala.CapienzaMassima)
                    {
                        sala.BigliettiVenduti.Add(biglietto);
                       
                       TempData["Message"] = "Biglietto venduto con successo!";


                    }
                    else
                    {
                        ViewBag.Message = "Non ci sono posti disponibili in questa sala.";
                    }
                }
               
            }
          

            return View(biglietto); // Passa il modello alla vista
        }


        /// /////////////////////////////////////////////////////////////////////

        public IActionResult Index()
        {
            var sale = CinemaData.Sale ?? new List<Sala>();
            return View(sale);
        }

        public IActionResult Riepilogo()
        {
            var biglietti = CinemaData.Sale?.SelectMany(s => s.BigliettiVenduti).ToList() ?? new List<Biglietto>();
            return View(biglietti);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
