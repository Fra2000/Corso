const arraylist = function (books) {
  const list = document.getElementById("library");
  books.forEach((book) => {
    const newli = document.createElement("li");
    newli.classList.add("list-group-item");
    newli.innertext = `${book.asin} - ${book.title} - ${book.image} - ${book.price} - ${book.category}`;

    list.appendChild(newli);
  });
};

const getlibrary = function () {
  fetch("https://striveschool-api.herokuapp.com/books", {})
    .then((response) => {
      if (response.ok) {
        console.log("FORSE sei in grado di concludere qualcosa", response);
        return response.json();
      } else {
        throw new Error("errore");
      }
    })
    .then((array) => {
      console.log("estraggo il body dalla response", array);
      arraylist(array);
    })
    .catch((err) => {
      console.log("Errore", err);
    });
};

getlibrary();
