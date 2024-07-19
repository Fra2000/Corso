using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using quintogiorno.DAO;
using quintogiorno.Models;

namespace quintogiorno.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaliContext _context;

        public VerbaleController(VerbaliContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var verbali = _context.Verbales.ToList();
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewData["Anagraficas"] = _context.Anagraficas.ToList();
            ViewData["TipoViolaziones"] = _context.TipoViolaziones.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Verbales.Add(verbale);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Anagraficas"] = _context.Anagraficas.ToList();
            ViewData["TipoViolaziones"] = _context.TipoViolaziones.ToList();
            return View(verbale);
        }

        public IActionResult Edit(int id)
        {
            var verbale = _context.Verbales.Find(id);
            if (verbale == null)
            {
                return NotFound();
            }
            ViewData["Anagraficas"] = _context.Anagraficas.ToList();
            ViewData["TipoViolaziones"] = _context.TipoViolaziones.ToList();
            return View(verbale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Verbale verbale)
        {
            if (id != verbale.IDVerbale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Verbales.Update(verbale);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Anagraficas"] = _context.Anagraficas.ToList();
            ViewData["TipoViolaziones"] = _context.TipoViolaziones.ToList();
            return View(verbale);
        }
    }
}
