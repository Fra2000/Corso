// noi vogliamo recuperare i dettagli di UN SINGOLO EVENTO
// GET su "https://striveschool-api.herokuapp.com/api/agenda" -> TUTTI GLI EVENTI PRESENTI IN DB
// GET su "https://striveschool-api.herokuapp.com/api/agenda/_id" -> UN EVENTO IN PARTICOLARE

// all'avvio della pagina dettagli noi vogliamo caricare i dati FRESCHI del concerto in questione
// lo faremo con una GET molto specifica grazie all'_id del concerto che ci siamo passati nella barra degli indirizzi

const addressBarContent = new URLSearchParams(location.search); // isola i parametri nel contenuto della barra degli indirizzi
console.log(addressBarContent);
const eventId = addressBarContent.get("eventId");

const getEventData = function () {
  fetch(`https://striveschool-api.herokuapp.com/api/product/${eventId}`, {
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZGIyNjgxODQ0MjAwMTUzNzU4OTUiLCJpYXQiOjE3MTUzMjk4MzAsImV4cCI6MTcxNjUzOTQzMH0.l3jJvaLNFwmUUpyzR3yKOSeRBR0tFrIAlwBmz_kBwD4",
    },
  })
    // https://striveschool-api.herokuapp.com/api/agenda/663c94ccb1c77f00150684b6
    // una chiamata GET fatta così NON CI TORNA TUTTI GLI EVENTI, ma UNO nello specifico!
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Errore nel recupero dei dettagli dell'evento");
      }
    })
    .then((event) => {
      console.log("DETTAGLI RECUPERATI", event);
      // ora manipolo il DOM e riempio la card
      document.getElementById("name").innerText = event.name;
      document.getElementById("description").innerText = event.description;
      document.getElementById("brand").innerText = event.brand;
      document.getElementById(
        "photos"
      ).innerHTML = ` <img src="${event.imageUrl}" class="card-img-top" alt="..."></img>`;
      document.getElementById("price").innerText = event.price + "€";
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

getEventData();

// funzione ELIMINA
const deleteEvent = function () {
  // per ELIMINARE una risorsa da un DB è necessario fare una fetch utilizzando il metodo "DELETE"
  // la chiamata DELETE funziona SOLO con un indirizzo comprendente alla fine l'_id della risorsa
  fetch(`https://striveschool-api.herokuapp.com/api/product/${eventId}`, {
    method: "DELETE",
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZGIyNjgxODQ0MjAwMTUzNzU4OTUiLCJpYXQiOjE3MTUzMjk4MzAsImV4cCI6MTcxNjUzOTQzMH0.l3jJvaLNFwmUUpyzR3yKOSeRBR0tFrIAlwBmz_kBwD4",
    },
    // qua non serve né body né "Content-Type"
  })
    .then((response) => {
      if (response.ok) {
        // abbiamo eliminato con successo la risorsa!
        alert("RISORSA ELIMINATA");
        location.assign("teapot_index.html"); // torniamo in home
      } else {
        // l'eliminazione della risorsa NON è andata a buon fine :(
        alert("ERRORE - RISORSA NON ELIMINATA");
      }
    })
    .catch((err) => {
      console.log("ERR", err);
    });
};

// LOGICA DI MODIFICA
// troviamo il bottone modifica nella pagina dettaglio
const editButton = document.getElementById("edit-button");
editButton.addEventListener("click", function () {
  location.assign(`backoffice.html?eventId=${eventId}`);
});
