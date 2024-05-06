class Utente {
  constructor(_firstName, _lastName, _age, _location) {
    this.firstName = _firstName;
    this.lastName = _lastName;
    this.age = _age;
    this.location = _location;
  }
}

const topolino = new Utente("Topolino", "non lo so", "20", "castello disney");

const paperino = new Utente("Paperino", "non lo so", "18", "castello disney");

const pippo = new Utente("Pippo", "non lo so", "21", "castello disney");

const comparazione = function (a, b) {
  const etàa = parseInt(a.age);
  const etàb = parseInt(b.age);

  if (etàa < etàb) {
    console.log(a.firstName + " è più piccolo di " + b.firstName);
  } else if (etàa > etàb) {
    console.log(a.firstName + " è più grande di " + b.firstName);
  } else {
    console.log(a.firstName + " ha la stessa età di " + b.firstName);
  }
};

comparazione(topolino, paperino);
