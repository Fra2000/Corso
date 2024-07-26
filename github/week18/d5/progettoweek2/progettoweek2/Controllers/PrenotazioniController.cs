using Microsoft.AspNetCore.Mvc;
using progettoweek2.DAO;
using progettoweek2.Models;
using System;

namespace progettoweek2.Controllers
{
    // Prenotazioni Controller
    [ApiController]
    [Route("api/Prenotazioni")]
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
    }

    // Clienti Controller
    [ApiController]
    [Route("api/Clienti")]
    public class ClientiController : ControllerBase
    {
        private readonly ClienteDao clienteDao;

        public ClientiController(ClienteDao clienteDao)
        {
            this.clienteDao = clienteDao;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clienti = clienteDao.GetAllClienti();
            return Ok(clienti);
        }
    }

    // Camere Controller
    [ApiController]
    [Route("api/Camere")]
    public class CamereController : ControllerBase
    {
        private readonly CameraDao cameraDao;

        public CamereController(CameraDao cameraDao)
        {
            this.cameraDao = cameraDao;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var camere = cameraDao.GetAllCamere();
            return Ok(camere);
        }
    }

    // ClienteCamera Controller
    [ApiController]
    [Route("api/ClienteCamera")]
    public class ClienteCameraController : ControllerBase
    {
        private readonly ClienteDao clienteDao;
        private readonly CameraDao cameraDao;

        public ClienteCameraController(ClienteDao clienteDao, CameraDao cameraDao)
        {
            this.clienteDao = clienteDao;
            this.cameraDao = cameraDao;
        }

        [HttpPost("CreateClienteCamera")]
        public IActionResult CreateClienteCamera([FromBody] ClienteCameraDTO dto)
        {
            Cliente cliente = new Cliente
            {
                CodiceFiscale = dto.Cliente.CodiceFiscale,
                Nome = dto.Cliente.Nome,
                Cognome = dto.Cliente.Cognome,
                Citta = dto.Cliente.Citta,
                Provincia = dto.Cliente.Provincia,
                Email = dto.Cliente.Email,
                Telefono = dto.Cliente.Telefono,
                Cellulare = dto.Cliente.Cellulare
            };

            Camera camera = new Camera
            {
                NumeroCamera = dto.Camera.NumeroCamera,
                Descrizione = dto.Camera.Descrizione,
                Tipologia = dto.Camera.Tipologia
            };

            bool clienteCreated = clienteDao.AddCliente(cliente);
            bool cameraCreated = cameraDao.AddCamera(camera);

            if (clienteCreated && cameraCreated)
            {
                return Ok(new { message = "Cliente e Camera creati con successo" });
            }
            return BadRequest(new { message = "Errore nella creazione di Cliente e Camera" });
        }
    }

    public class ClienteCameraDTO
    {
        public ClienteDTO Cliente { get; set; }
        public CameraDTO Camera { get; set; }
    }

    public class ClienteDTO
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
    }

    public class CameraDTO
    {
        public int NumeroCamera { get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }
    }
}
