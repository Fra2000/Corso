// riempiamo la riga con gli eventi
// https://striveschool-api.herokuapp.com/api/agenda

const generateConcertCards = function (teapotArray) {
  const row = document.getElementById("events-row");
  teapotArray.forEach((teapot) => {
    const newCol = document.createElement("div");
    newCol.classList.add("col");
    newCol.innerHTML = `
      <div class="card h-100 d-flex flex-column">
      <div class="card-body d-flex flex-column justify-content-around">
      <h5 class="card-title">${teapot.name}</h5>
      <p class="card-text">${teapot.description}</p>
      <p class="card-text">${teapot.brand}</p>
      <a href="details.html?eventId=${teapot._id}"><img src="${teapot.imageUrl}" class="card-img-top" alt="..."></a> 
          <div class="d-flex justify-content-between">
            <button class="btn btn-primary">${teapot.price}€</button>
            <button id="edit-button" class="btn btn-warning">MODIFICA</button>
          </div>
        </div>
      </div>
      `;

    row.appendChild(newCol);
  });
};

const getEvents = function () {
  //  recuperiamo la lista di eventi attualmente nel database
  fetch("https://striveschool-api.herokuapp.com/api/product/", {
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZGIyNjgxODQ0MjAwMTUzNzU4OTUiLCJpYXQiOjE3MTUzMjk4MzAsImV4cCI6MTcxNjUzOTQzMH0.l3jJvaLNFwmUUpyzR3yKOSeRBR0tFrIAlwBmz_kBwD4",
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log(response);
        return response.json();
      } else {
        throw new Error("Errore nella risposta del server");
      }
    })
    .then((array) => {
      console.log("ARRAY!", array);
      // creiamo le card per la landing page
      generateConcertCards(array);
    })
    .catch((err) => {
      console.log("ERRORE!", err);
    });
};

getEvents();
