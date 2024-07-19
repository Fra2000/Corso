using Microsoft.AspNetCore.Mvc;
using quintogiorno.DAO;
using quintogiorno.Models;
using System.Linq;

namespace quintogiorno.Controllers
{
    public class ReportController : Controller
    {
        private readonly VerbaliContext _context;

        public ReportController(VerbaliContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TotalVerbaliPerTrasgressore()
        {
            var report = _context.Verbales
                .GroupBy(v => v.Anagrafica)
                .Select(g => new
                {
                    Trasgressore = $"{g.Key.Cognome}, {g.Key.Nome}", // Concatenazione di Cognome e Nome
                    TotaleVerbali = g.Count()
                })
                .ToList();

            return View(report);
        }

        public IActionResult TotalPuntiDecurtatiPerTrasgressore()
        {
            var report = _context.Verbales
                .GroupBy(v => v.Anagrafica)
                .Select(g => new
                {
                    Trasgressore = $"{g.Key.Cognome}, {g.Key.Nome}", // Concatenazione di Cognome e Nome
                    TotalePuntiDecurtati = g.Sum(v => v.DecurtamentoPunti)
                })
                .ToList();

            return View(report);
        }

        public IActionResult ViolazioniOltreDieciPunti()
        {
            var report = _context.Verbales
                .Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new
                {
                    Importo = v.Importo,
                    Cognome = v.Anagrafica.Cognome,
                    Nome = v.Anagrafica.Nome,
                    DataViolazione = v.DataViolazione,
                    DecurtamentoPunti = v.DecurtamentoPunti
                })
                .ToList();

            return View(report);
        }

        public IActionResult ViolazioniImportoMaggioreDiQuattrocento()
        {
            var report = _context.Verbales
                .Where(v => v.Importo > 400)
                .Select(v => new
                {
                    Importo = v.Importo,
                    Cognome = v.Anagrafica.Cognome,
                    Nome = v.Anagrafica.Nome,
                    DataViolazione = v.DataViolazione
                })
                .ToList();

            return View(report);
        }

    }
}
