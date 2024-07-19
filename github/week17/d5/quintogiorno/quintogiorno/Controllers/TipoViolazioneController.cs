using Microsoft.AspNetCore.Mvc;
using quintogiorno.DAO;
using quintogiorno.Models;

namespace quintogiorno.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneDAO _tipoViolazioneDAO;

        public TipoViolazioneController(TipoViolazioneDAO tipoViolazioneDAO)
        {
            _tipoViolazioneDAO = tipoViolazioneDAO;
        }

        public IActionResult Index()
        {
            var tipoViolazioni = _tipoViolazioneDAO.GetAll();
            return View(tipoViolazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _tipoViolazioneDAO.Add(tipoViolazione);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoViolazione);
        }

        public IActionResult Edit(int id)
        {
            var tipoViolazione = _tipoViolazioneDAO.GetById(id);
            if (tipoViolazione == null)
            {
                return NotFound();
            }
            return View(tipoViolazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TipoViolazione tipoViolazione)
        {
            if (id != tipoViolazione.IDViolazione)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _tipoViolazioneDAO.Update(tipoViolazione);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoViolazione);
        }

        public IActionResult Delete(int id)
        {
            var tipoViolazione = _tipoViolazioneDAO.GetById(id);
            if (tipoViolazione == null)
            {
                return NotFound();
            }
            return View(tipoViolazione);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tipoViolazione = _tipoViolazioneDAO.GetById(id);
            if (tipoViolazione == null)
            {
                return NotFound();
            }

            _tipoViolazioneDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
