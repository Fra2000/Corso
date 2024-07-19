using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quintogiorno.DAO;
using quintogiorno.Models;
using System.Linq;

namespace quintogiorno.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaDAO _anagraficaDAO;

        public AnagraficaController(AnagraficaDAO anagraficaDAO)
        {
            _anagraficaDAO = anagraficaDAO;
        }

        public IActionResult Index()
        {
            var anagrafiche = _anagraficaDAO.GetAll();
            return View(anagrafiche);
        }

        public IActionResult Details(int id)
        {
            var anagrafica = _anagraficaDAO.GetById(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaDAO.Add(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        public IActionResult Edit(int id)
        {
            var anagrafica = _anagraficaDAO.GetById(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Anagrafica anagrafica)
        {
            if (id != anagrafica.IDAnagrafica)
            {
                return BadRequest();
            }

            // Debug: Verifica il contenuto di 'anagrafica'
            System.Diagnostics.Debug.WriteLine($"IDAnagrafica: {anagrafica.IDAnagrafica}");
            System.Diagnostics.Debug.WriteLine($"Nome: {anagrafica.Nome}");
            // Aggiungi ulteriori scritture per altri campi se necessario

            if (ModelState.IsValid)
            {
                try
                {
                    _anagraficaDAO.Update(anagrafica);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_anagraficaDAO.Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }



        public IActionResult Delete(int id)
        {
            var anagrafica = _anagraficaDAO.GetById(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _anagraficaDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
