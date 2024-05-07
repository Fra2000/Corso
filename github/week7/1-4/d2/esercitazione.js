const nuser = document.getElementById("nuser");
const password = document.getElementById("password");
const form = document.getElementsByTagName("form")[0];

const salvap = function () {
  const contentname = nuser.value;
  const contentp = password.value;
  localStorage.setItem("nome", contentname);
  localStorage.setItem("password", contentp);
};

const rimuovip = function () {
  const recuperan = document.createElement("div");
  const recuperano = localStorage.getItem("nome");
  const recuperap = document.createElement("div");
  const recuperapa = localStorage.getItem("password");
  recuperan.textContent = "nome utente cancellato: " + recuperano;
  recuperap.textContent = "password cancellata: " + recuperapa;
  recuperan.classList.add("text-center", "mt-3");
  recuperap.classList.add("text-center");
  form.parentNode.insertBefore(recuperan, form);
  form.parentNode.insertBefore(recuperap, form);
  localStorage.removeItem("nome");
  localStorage.removeItem("password");
};

const salva = document
  .getElementById("salva")
  .addEventListener("click", salvap);
const rimuovi = document
  .getElementById("rimuovi")
  .addEventListener("click", rimuovip);
