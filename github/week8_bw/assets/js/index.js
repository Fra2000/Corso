//Funzione SALUTO (Vedi header)
function saluto() {
  var oraAttuale = new Date().getHours();
  var salutoElement = document.getElementById("salutoPlaceholder");
  if (oraAttuale >= 4 && oraAttuale < 17) {
    salutoElement.textContent = "Buongiorno";
  } else {
    salutoElement.textContent = "Buonasera";
  }
}
document.addEventListener("DOMContentLoaded", function () {
  saluto();
});

//Fetch 1
const getYourFavsUno = function () {
  fetch(`https://striveschool-api.herokuapp.com/api/deezer/album/7927764`)
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);
      const yourFavsList = document.getElementById("yourFavs");

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite bg-spotifyPrimary text-light" id="cardDiv">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            </div>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });
  fetch("https://striveschool-api.herokuapp.com/api/deezer/album/75621062")
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);
      const yourFavsList = document.getElementById("yourFavs");

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite hoverTransitionWhite bg-spotifyPrimary text-light  id="cardDiv"">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            </div>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });
  fetch("https://striveschool-api.herokuapp.com/api/deezer/album/304178047")
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);
      const yourFavsList = document.getElementById("yourFavs");

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite bg-spotifyPrimary text-light" id="cardDiv">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });
  fetch("https://striveschool-api.herokuapp.com/api/deezer/album/560451292")
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);
      const yourFavsList = document.getElementById("yourFavs");

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite bg-spotifyPrimary text-light" id="cardDiv">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });
  fetch("https://striveschool-api.herokuapp.com/api/deezer/album/108706862")
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      const yourFavsList = document.getElementById("yourFavs");
      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite bg-spotifyPrimary text-light" id="cardDiv">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });

  fetch("https://striveschool-api.herokuapp.com/api/deezer/album/501524281")
    .then((response) => {
      if (response.ok) {
        console.log("Yeah", response);
        return response.json();
      } else {
        throw new Error("Brava, hai sbagliato");
      }
    })
    //Estraggo
    .then((albums) => {
      console.log("Ho estratto il body", albums);
      const yourFavsList = document.getElementById("yourFavs");

      //Canzone randomica
      const song = getRandomSongFromAlbum(albums);
      console.log("Canzone random", song);

      //DOM Manipulation
      const newAlbum = document.createElement("div");
      newAlbum.classList.add("col");
      newAlbum.innerHTML = `
            <div class="card hoverTransitionWhite bg-spotifyPrimary text-light" id="cardDiv">
                <img src="${albums.cover_medium}" class="card-img-top p-2 rounded-4" alt="...">
                <div class="card-body">
                    <h5 class="card-title fw-bold">${song.title}</h5>
                    <p class="card-artist text-spotifyQuartary">${albums.artist.name}</p>
            `;
      yourFavsList.appendChild(newAlbum);
    })

    .catch((err) => {
      console.log("Fai schifo", err);
    });

  // FUNZIONE Random song
  const getRandomSongFromAlbum = function (albumObject) {
    if (albumObject.nb_tracks === 0) {
      return "Non ci sono canzoni";
    } else {
      const randomSong = Math.floor(Math.random() * albumObject.nb_tracks);
      return albumObject.tracks.data[randomSong];
    }
  };
};
getYourFavsUno();

//FETCH Music player
const getOneMusicToPlay = function () {
  const randomLetter = getRandomLetter();
  const url = `https://striveschool-api.herokuapp.com/api/deezer/search?q=${randomLetter}`;

  fetch(url)
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Qualcosa è andato storto durante la richiesta");
      }
    })
    .then((data) => {
      const songs = data.data.map((result) => result);

      const musicPlayer = document.getElementById("musicPlayer");
      for (let i = 0; i < songs.length && i < 1; i++) {
        const song = songs[i];
        const newSong = document.createElement("div");
        newSong.classList.add("d-flex");
        newSong.classList.add("w-100");
        newSong.innerHTML = `
          <div>
            <img src="${song.album.cover_medium}" class="me-3 mt-4 mb-3" alt="${song.album.title}" style="width: 200px; height: 200px;"> 
          </div>
          <div class="d-flex flex-column justify-content-between">
            <div class="d-flex flex-column">
              <h1 class="mt-3">${song.title}</h1>
              <p>${song.artist.name}</p>
              <p>Ascolta ora il nuovo album di ${song.artist.name}!</p>
              <div class="mt-2 mb-3">
                <button type="button" class="btn px-4 btn-spotifySecondary rounded-5 fw-bold" id="button">Play</button>
                <button type="button" class="btn px-4 btn-spotifyPrimary border-light text-spotifyQuartary rounded-5 fw-bold" id="button">Salva</button>
                <button type="button" class="btn px-4 btn-spotifyPrimary text-spotifyQuartary rounded-5 fw-bold" id="button"><i class="bi bi-three-dots"></i></button>
              </div>
            </div>
          </div>
          <div class="ms-auto mt-2 "> 
            <button type="button" class="btn btn-spotifyTertiary text-spotifyQuartary rounded-5 btn-sm" id="button">NASCONDI ANNUNCI</button>
          </div>
        `;
        musicPlayer.appendChild(newSong);
      }
    })
    .catch((err) => {
      console.error("Si è verificato un errore durante la richiesta:", err);
    });
};

document.addEventListener("DOMContentLoaded", function () {
  getOneMusicToPlay();
});

//FETCH Artisti scelti per te
function getRandomLetter() {
  const alphabet = "abcdefghijklmnopqrstuvwxyz";
  const randomIndex = Math.floor(Math.random() * alphabet.length);
  return alphabet[randomIndex];
}

function getArtistsByRandomLetter() {
  const randomLetter = getRandomLetter();
  const url = `https://striveschool-api.herokuapp.com/api/deezer/search?q=${randomLetter}`;

  return fetch(url)
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Errore nella richiesta:");
      }
    })
    .then((data) => {
      const artists = data.data.map((result) => result.artist);
      console.log("ARTISTI", artists);

      // DOM
      for (let i = 0; i < artists.length && i < 6; i++) {
        const artist = artists[i];
        const artistElement = document.createElement("div");
        artistElement.classList.add("col");
        artistElement.classList.add("mb-5");

        artistElement.innerHTML = `
                <div class="card text-light bg-spotifyPrimary rounded-circle pointer" id="cardDiv">
                    <img src="${artist.picture_big}" a href="./artistPage.html?artistId=${artist.id}" class="card-img-top rounded-circle hoverTransitionWhite" alt="...">
                    <div class="card-body">
                        <h5 class="card-title fw-bold">${artist.name}</h5>
                        <p class="card-artist text-spotifyQuartary">Artista</p>
                    </div>
                </div>
            `;

        const artistsContainer = document.getElementById("yourArtist");
        artistsContainer.appendChild(artistElement);
      }
    })

    .catch((error) => {
      console.error("Si è verificato un errore:", error);
    });
}
getArtistsByRandomLetter();

//FETCH Album scelti per te

function getAlbumsByRandomLetter() {
  const randomLetter = getRandomLetter();
  const url = `https://striveschool-api.herokuapp.com/api/deezer/search?q=${randomLetter}`;

  return fetch(url)
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Errore nella richiesta:");
      }
    })
    .then((data) => {
      const yourAlb = data.data.map((result) => result.album);
      console.log(yourAlb);

      // DOM
      for (let i = 0; i < yourAlb.length && i < 6; i++) {
        const album = yourAlb[i];
        const albElement = document.createElement("div");
        albElement.classList.add("col");
        albElement.classList.add("mb-5");

        albElement.innerHTML = `
                <div class="card text-light bg-spotifyPrimary pointer" id="cardDiv">
                    <img src="${album.cover_medium}" class="card-img-top hoverTransitionWhite" alt="...">
                    <div class="card-body">
                        <h5 class="card-title fw-bold">${album.title}</h5>

                    </div>
                </div>
            `;

        const albumContainer = document.getElementById("yourAlbums");
        albumContainer.appendChild(albElement);
      }
    })

    .catch((error) => {
      console.error("Si è verificato un errore:", error);
    });
}
getAlbumsByRandomLetter();
