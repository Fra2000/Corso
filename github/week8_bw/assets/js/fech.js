class Artist {
  constructor(_name, _picturexl, _nb_fan) {
    this.name = _name;
    this.picturexl = _picturexl;
    this.nb_fan = _nb_fan;
  }
}
const addressBarContent = new URLSearchParams(location.search);
const eventId = addressBarContent.get("eventId");
// Assegno temporanemamete l'artista
//eventId = 571; // queen
console.log("eventId?", eventId);

const getArtistDetails = function () {
  fetch("https://striveschool-api.herokuapp.com/api/deezer/artist/" + eventId)
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
    })
    .then((artistData) => {
      console.log("Artist data:", artistData);

      // Creazione dell'oggetto Artista
      const artist = new Artist(
        artistData.name,
        artistData.picture_xl,
        artistData.nb_fan
      );

      // Inserimento dei dati nel DOM
      document.querySelectorAll(".artistName").forEach((el) => {
        el.innerText = artist.name;
      });
      document.getElementById("artImgUrl").src = artist.picturexl;
      document.getElementById("numeroDiFan").innerText = `${(
        artist.nb_fan / 1000000
      ).toFixed(1)} Mln di ascolti mensili`;
    })
    .catch((error) => {
      console.error("Error fetching artist data:", error);
    });
};

getArtistDetails();

class CanzoniPiuPopolari {
  constructor(
    title,
    pictureMedium,
    preview,
    duration,
    rank,
    albumTitle,
    albumCover,
    albumLink
  ) {
    this.title = title;
    this.pictureMedium = pictureMedium;
    this.preview = preview;
    this.duration = duration;
    this.rank = rank;
    this.albumTitle = albumTitle;
    this.albumCover = albumCover;
    this.albumLink = albumLink;
  }

  static fromJSON(data) {
    return new CanzoniPiuPopolari(
      data.title,
      // Assicurati che il percorso completo dell'immagine sia incluso
      "https://path/to/images/" + data.picture_medium,
      data.preview,
      data.duration,
      data.rank,
      data.album.title,
      data.album.cover_small,
      data.album.link
    );
  }
}

const getTopSongs = function () {
  fetch(
    "https://striveschool-api.herokuapp.com/api/deezer/artist/" +
      eventId +
      "/top?limit=50"
  )
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
    })
    .then((data) => {
      console.log("Top songs:", data);

      // Filtra solo le prime 10 canzoni popolari
      const top10Songs = data.data.slice(0, 10);

      // Ordina le canzoni in base al rank (in ordine decrescente)
      const songs = top10Songs
        .map((songData) => CanzoniPiuPopolari.fromJSON(songData))
        .sort((a, b) => b.rank - a.rank);

      // Inserisci i dati delle canzoni nel DOM
      const cardContainer = document.getElementById("popularSongTotal");
      if (cardContainer) {
        // Funzione per mostrare le canzoni
        const showSongs = (songsToShow) => {
          cardContainer.innerHTML = "";
          songsToShow.forEach((song, index) => {
            cardContainer.innerHTML += `
                              <div class="d-flex align-content-center flex-wrap ps-3 ">
                                  <div id="firtSection" class="d-flex">
                                      <div class="d-flex flex-row">
                                          <p id="numberSection" class="m-3 align-content-center">${
                                            index + 1
                                          }</p>
                                      </div>
                                      <div id="imageSection" class="align-content-center">
                                          <img src="${
                                            song.albumCover
                                          }" width="auto" height="45" alt="Cover Song">
                                      </div>
                                  </div>
                                  <div class="d-flex flex-column flex-lg-row align-content-center ms-3" id="informationPopularSong">
                                      <div id="idTitle">
                                          <p id="title" class="align-content-center m-0">${
                                            song.title
                                          }</p>
                                      </div>
                                      <div id="idReproductionNumber">
                                          <p id="reproductionNumber" class="align-content-center text-secondary m-0">${
                                            song.rank
                                          }</p>
                                      </div>
                                  </div>
                                  <div class=" d-flex flex-wrap align-content-center " id="ancillaryInformation">
                                      <div id="idAddToPlaylist">
                                          <p id="addToPlaylist" class="d-flex"> <i class="bi bi-plus-circle text-white me-4"></i> </p>
                                      </div>
                                      <div id="idsongDuration">
                                          <p id="songDuration" class="d-none d-lg-flex me-4">${Math.floor(
                                            song.duration / 60
                                          )}:${(song.duration % 60)
              .toString()
              .padStart(2, "0")}</p>
                                      </div>
                                      <div>
                                          <p id="songDuration"> <i class="bi bi-three-dots text-white d-none d-lg-block"></i> <i class="bi bi-three-dots-vertical d-lg-none"></i></p>
                                      </div>
                                  </div>
                              </div>`;
          });

          // Bottone "Mostra tutto"
          if (songsToShow.length >= 5 && songsToShow.length < 10) {
            cardContainer.innerHTML += `
                              <button id="showAllButton" class="btn btn-spotifyPrimary text-start mb-3 d-none d-lg-block">Mostra tutto</button>
                          `;
          }

          // Bottone "Mostra meno"
          if (songsToShow.length === 10) {
            cardContainer.innerHTML += `
                              <button id="showLessButton" class="btn btn-spotifyPrimary text-start mb-3">Mostra meno</button>
                          `;
          }

          // Aggiungi gli eventi ai bottoni
          const showAllButton = document.getElementById("showAllButton");
          if (showAllButton) {
            showAllButton.addEventListener("click", () => {
              showSongs(songs);
            });
          }

          const showLessButton = document.getElementById("showLessButton");
          if (showLessButton) {
            showLessButton.addEventListener("click", () => {
              showSongs(songs.slice(0, 5));
            });
          }
        };

        // Mostra le prime cinque canzoni
        showSongs(songs.slice(0, 5));
      }
    })
    .catch((error) => {
      console.error("Error fetching top songs:", error);
    });
};

// Chiamata alla funzione per ottenere le canzoni popolari dell'artista con ID 412
getTopSongs();

class TopRankedItem {
  constructor(title, type, cover, releaseYear) {
    this.title = title;
    this.type = type === "track" ? "Singolo" : type; // Se il tipo è "track", lo cambiamo in "Singolo"
    this.cover = cover; // URL dell'immagine della copertina dell'album o della traccia
    this.releaseYear = releaseYear; // Anno di uscita dell'album o della traccia
  }
}

const getTopAlbumsAndTracks = function () {
  fetch(
    "https://striveschool-api.herokuapp.com/api/deezer/artist/" +
      eventId +
      "/top?limit=50"
  )
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
    })
    .then((data) => {
      console.log("Top items:", data);

      // Filtra tracce
      const tracks = data.data.filter((item) => item.type === "track");

      // Genera un numero casuale di album da 1 a 10
      const numAlbums = Math.floor(Math.random() * 10) + 1;

      // Determina quanti track aggiungere sottraendo il numero di album dal totale delle tracce
      const numTracks = Math.max(10 - numAlbums, 0);

      // Ottieni gli ID degli album associati alle tracce selezionate
      const albumIds = tracks
        .slice(0, numTracks)
        .map((track) => track.album.id);

      // Effettua una seconda chiamata API per ottenere informazioni sugli album
      return Promise.all(
        albumIds.map((albumId) =>
          fetch(
            `https://striveschool-api.herokuapp.com/api/deezer/album/${albumId}`
          )
            .then((response) => {
              if (response.ok) {
                return response.json();
              } else {
                throw new Error(`HTTP error! status: ${response.status}`);
              }
            })
            .then((albumData) => albumData)
        )
      ).then((albumsData) => {
        // Mappa i dati degli album e crea gli oggetti TopRankedItem
        const topRankedAlbums = albumsData.map(
          (albumData) =>
            new TopRankedItem(
              albumData.title,
              "album",
              albumData.cover_medium,
              albumData.release_date
            )
        );

        // Inserisci i dati degli album nel DOM
        const discographySection =
          document.getElementById("discographySection");
        if (discographySection) {
          topRankedAlbums.forEach((item) => {
            discographySection.innerHTML += `
                              <div id="containerCard" class="mt-3 me-4">
                                  <div class="d-none d-lg-block" id="imageTop">
                                      <img src="${item.cover}" class="imageAlbum rounded" alt="Immagine Album">
                                  </div>
                                  <div class="d-flex" id="imageLeft">
                                      <div class="d-flex d-lg-none">
                                          <img src="${item.cover}" class="imageAlbum rounded" alt="Immagine Album">
                                      </div>
                                      <div>
                                          <div class="ms-3 mt-3">
                                              <p id="titleAlbum">${item.title}</p>
                                              <p><span id="tipo">${item.type}</span> <span id="annoDiUscita">${item.releaseYear}</span></p>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          `;
          });
        }

        // Inserisci le tracce rimanenti nel DOM
        const selectedTracks = tracks.slice(0, 10 - topRankedAlbums.length);
        discographySection.innerHTML += selectedTracks
          .map(
            (track) => `
                      <div id="containerCard" class="mt-3 me-4" >
                          <div class="d-none d-lg-block" id="imageTop">
                              <img src="${track.album.cover_medium}" class="imageAlbum rounded" alt="Immagine Album">
                          </div>
                          <div class="d-flex" id="imageLeft">
                              <div class="d-flex d-lg-none">
                                  <img src="${track.album.cover_medium}" class="imageAlbum rounded" alt="Immagine Album">
                              </div>
                              <div>
                                  <div class="ms-3 mt-3">
                                      <p id="titleAlbum">${track.title}</p>
                                      <p><span id="tipo">Singolo</span> </p>
                                  </div>
                              </div>
                          </div>
                      </div>
                  `
          )
          .join("");
      });
    })
    .catch((error) => {
      console.error("Error fetching top items:", error);
    });
};

// Chiamata alla funzione per ottenere i primi 10 album e tracce dell'artista con ID 412
getTopAlbumsAndTracks();

class Album {
  constructor(title, cover, releaseDate) {
    this.title = title;
    this.cover = cover;
    this.releaseDate = releaseDate;
  }
}

const getTopAlbums = function () {
  fetch(
    "https://striveschool-api.herokuapp.com/api/deezer/artist/" +
      eventId +
      "/top?limit=50"
  )
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
    })
    .then((data) => {
      console.log("Top items:", data);

      // Filtra tracce
      const tracks = data.data.filter((item) => item.type === "track");

      // Scegli un numero casuale di tracce (massimo 10)
      const numTracks = Math.min(tracks.length, 10);

      // Ottieni gli ID degli album associati alle tracce selezionate
      const albumIds = tracks
        .slice(0, numTracks)
        .map((track) => track.album.id);

      // Effettua una seconda chiamata API per ottenere informazioni sugli album
      return Promise.all(
        albumIds.map((albumId) =>
          fetch(
            `https://striveschool-api.herokuapp.com/api/deezer/album/${albumId}`
          )
            .then((response) => {
              if (response.ok) {
                return response.json();
              } else {
                throw new Error(`HTTP error! status: ${response.status}`);
              }
            })
            .then((albumData) => albumData)
        )
      );
    })
    .then((albumsData) => {
      // Mappa i dati degli album e crea gli oggetti Album
      const topAlbums = albumsData.map(
        (albumData) =>
          new Album(
            albumData.title,
            albumData.cover_medium,
            albumData.release_date
          )
      );

      // Inserisci i dati degli album nel DOM
      const discographySection = document.getElementById("albumSection");
      if (discographySection) {
        topAlbums.forEach((album) => {
          discographySection.innerHTML += `
                          <div id="containerCard">
                              <div class="d-none d-lg-block" id="imageTop">
                                  <img src="${album.cover}" class="imageAlbum rounded" alt="Immagine Album">
                              </div>
                              <div class="d-flex mt-3 me-4"  id="imageLeft">
                                  <div class="d-flex d-lg-none">
                                      <img src="${album.cover}" class="imageAlbum rounded" alt="Immagine Album">
                                  </div>
                                  <div>
                                      <div class="ms-3 mt-3">
                                          <p id="titleAlbum">${album.title}</p>
                                          <p><span id="tipo">Album</span> <span id="annoDiUscita">${album.releaseDate}</span></p>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      `;
        });
      }
    })
    .catch((error) => {
      console.error("Error fetching top items:", error);
    });
};

// Chiamata alla funzione per ottenere i top 10 album dell'artista
getTopAlbums();
