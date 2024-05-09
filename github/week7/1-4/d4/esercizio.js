const btnteapot = document.getElementById("btntea");
const btnsayan = document.getElementById("btnsayan");
const add = function () {
  fetch("https://api.pexels.com/v1/search?query=teapot", {
    method: "GET",
    headers: {
      Authorization: "heEcG0aHRHSvZF3eplhqIUL2WPPfu3RY7oDsRb5XEwivavMimi5ULBCt",
    },
  })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Errore nella risposta del server");
      }
    })
    .then((theteapot) => {
      console.log("ARRAY!", theteapot);
      const arrayOfPhotos = theteapot.photos;
      const cardImages = document.querySelectorAll(".card-img-top");
      arrayOfPhotos.forEach((photo, index) => {
        if (index < cardImages.length) {
          cardImages[index].src = photo.src.medium;
          cardImages[index].alt = photo.photographer;
        }
      });
    })
    .catch((err) => {
      console.log("ERRORE!", err);
    });
};

const sayan = function () {
  fetch("https://api.pexels.com/v1/search?query=monkey", {
    method: "GET",
    headers: {
      Authorization: "heEcG0aHRHSvZF3eplhqIUL2WPPfu3RY7oDsRb5XEwivavMimi5ULBCt",
    },
  })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Errore nella risposta del server");
      }
    })
    .then((theteapot) => {
      console.log("ARRAY!", theteapot);
      const arrayOfPhotos = theteapot.photos;
      const cardImages = document.querySelectorAll(".card-img-top");
      arrayOfPhotos.forEach((photo, index) => {
        if (index < cardImages.length) {
          cardImages[index].src = photo.src.medium;
          cardImages[index].alt = photo.photographer;
        }
      });
    })
    .catch((err) => {
      console.log("ERRORE!", err);
    });
};

btnteapot.addEventListener("click", add);
btnsayan.addEventListener("click", sayan);
//heEcG0aHRHSvZF3eplhqIUL2WPPfu3RY7oDsRb5XEwivavMimi5ULBCt
