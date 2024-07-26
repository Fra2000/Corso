using Microsoft.AspNetCore.Mvc;
using progettoweek2.DAO;
using progettoweek2.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
{
    private readonly PrenotazioneDao prenotazioneDao;

    public PrenotazioniController(PrenotazioneDao prenotazioneDao)
    {
        this.prenotazioneDao = prenotazioneDao;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var prenotazioni = prenotazioneDao.GetAllPrenotazioni();
        return Ok(prenotazioni);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var prenotazione = prenotazioneDao.GetPrenotazioneById(id);
        if (prenotazione != null)
            return Ok(prenotazione);
        return NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Prenotazione prenotazione)
    {
        prenotazioneDao.AddPrenotazione(prenotazione);
        return Ok(prenotazione);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Prenotazione prenotazione)
    {
        prenotazione.ID = id;
        var result = prenotazioneDao.UpdatePrenotazione(prenotazione);
        if (result)
            return Ok();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = prenotazioneDao.DeletePrenotazione(id);
        if (result)
            return Ok();
        return NotFound();
    }

    [HttpGet("{id}/checkout")]
    public IActionResult GetCheckoutDetails(int id)
    {
        var prenotazione = prenotazioneDao.GetPrenotazioneById(id);
        if (prenotazione == null)
            return NotFound();

        // Otteniamo il ClienteID associato alla prenotazione
        var clienteId = prenotazioneDao.GetClienteIdByPrenotazioneId(id);

        // Otteniamo il CameraID associato al ClienteID
        var cameraId = prenotazioneDao.GetCameraIdByClienteId(clienteId);

        // Otteniamo il numero della camera
        var numeroCamera = prenotazioneDao.GetNumeroCameraById(cameraId);

        var serviziAggiuntivi = prenotazioneDao.GetServiziAggiuntiviByPrenotazioneId(id);

        var totaleServiziAggiuntivi = serviziAggiuntivi.Sum(s => s.Prezzo * s.Quantita);
        var importoDaSaldare = prenotazione.Tariffa - prenotazione.Caparra + totaleServiziAggiuntivi;

        var dettagliCheckout = new
        {
            NumeroCamera = numeroCamera,
            Periodo = $"{prenotazione.DataInizio.ToShortDateString()} - {prenotazione.DataFine.ToShortDateString()}",
            Tariffa = prenotazione.Tariffa,
            ServiziAggiuntivi = serviziAggiuntivi,
            ImportoDaSaldare = importoDaSaldare
        };

        return Ok(dettagliCheckout);
    }


}
