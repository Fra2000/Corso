/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per visualizzare l'output, lancia il file HTML a cui è collegato e apri la console dagli strumenti di sviluppo del browser. 
- Utilizza dei console.log() per testare le tue variabili e/o i risultati delle espressioni che stai creando.
*/

/* ESERCIZIO 1
    Dato il seguente array, scrivi del codice per stampare ogni elemento dell'array in console.
*/
const pets = ['dog', 'cat', 'hamster', 'redfish']

for (let i=0; i<pets.length; i++) {
console.log(pets[i])};

/* ESERCIZIO 2
    Scrivi del codice per ordinare alfabeticamente gli elementi dell'array "pets".
*/

pets.sort();
console.log(pets);

/* ESERCIZIO 3
    Scrivi del codice per stampare nuovamente in console gli elementi dell'array "pets", questa volta in ordine invertito.
*/

pets.reverse();
console.log(pets);

/* ESERCIZIO 4
    Scrivi del codice per spostare il primo elemento dall'array "pets" in ultima posizione.
*/

const primopets=pets.shift();
pets.push(primopets);
console.log(pets);

/* ESERCIZIO 5
    Dato il seguente array di oggetti, scrivi del codice per aggiungere ad ognuno di essi una proprietà "licensePlate" con valore a tua scelta.
*/
const cars = [
  {
    brand: 'Ford',
    model: 'Fiesta',
    color: 'red',
    trims: ['titanium', 'st', 'active'],
  },
  {
    brand: 'Peugeot',
    model: '208',
    color: 'blue',
    trims: ['allure', 'GT'],
  },
  {
    brand: 'Volkswagen',
    model: 'Polo',
    color: 'black',
    trims: ['life', 'style', 'r-line'],
  },
]

for(let i=0; i<cars.length; i++){
  cars[i].licensePlate='1';
}
console.log(cars);

/* ESERCIZIO 6
    Scrivi del codice per aggiungere un nuovo oggetto in ultima posizione nell'array "cars", rispettando la struttura degli altri elementi.
    Successivamente, rimuovi l'ultimo elemento della proprietà "trims" da ogni auto.
*/

const newcar={ 
    brand: 'Toyota',
    model: 'hybrid',
    color: 'green',
    trims: ['life', 'active']
}
cars.push(newcar);
for (let i=0; i<cars.length; i++){
  let car=cars[i];
  car.trims.pop();
}
console.log(cars);

/* ESERCIZIO 7
    Scrivi del codice per salvare il primo elemento della proprietà "trims" di ogni auto nel nuovo array "justTrims", sotto definito.
*/
const justTrims = []
for (let i=0; i<cars.length; i++) {
  let trims=cars[i].trims[0];
  justTrims.push(trims);
}
console.log(justTrims);

/* ESERCIZIO 8
    Cicla l'array "cars" e costruisci un if/else statament per mostrare due diversi messaggi in console. Se la prima lettera della proprietà
    "color" ha valore "b", mostra in console "Fizz". Altrimenti, mostra in console "Buzz".
*/
for (let i=0; i<cars.length; i++){
  let letter=cars[i].color.charAt(0);
  if(letter==="b"){
  console.log("Fizz");}
else{
  console.log("Buzz");}
}

/* ESERCIZIO 9
    Utilizza un ciclo while per stampare in console i valori del seguente array numerico fino al raggiungimento del numero 32.
*/
const numericArray = [
  6, 90, 45, 75, 84, 98, 35, 74, 31, 2, 8, 23, 100, 32, 66, 313, 321, 105,
]
var number32=0;
while(number32<numericArray.length && numericArray[number32] !==32){
  console.log(numericArray[number32]);
  number32++;
}

/* ESERCIZIO 10
    Partendo dall'array fornito e utilizzando un costrutto switch, genera un nuovo array composto dalle posizioni di ogni carattere all'interno
    dell'alfabeto italiano.
    es. [f, b, e] --> [6, 2, 5]
*/

const charactersArray = ['g', 'n', 'u', 'z', 'd'];

const alphabetItalian = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'z'];

const positionsArray = [];

for (let i = 0; i < charactersArray.length; i++) {
  const character = charactersArray[i].toLowerCase();
  switch (character) {
    case 'a':
      positionsArray.push(alphabetItalian.indexOf('a') + 1);
      break;
    case 'b':
      positionsArray.push(alphabetItalian.indexOf('b') + 1);
      break;
    case 'c':
      positionsArray.push(alphabetItalian.indexOf('c') + 1);
      break;
    case 'd':
      positionsArray.push(alphabetItalian.indexOf('d') + 1);
      break;
    case 'e':
      positionsArray.push(alphabetItalian.indexOf('e') + 1);
      break;
    case 'f':
      positionsArray.push(alphabetItalian.indexOf('f') + 1);
      break;
    case 'g':
      positionsArray.push(alphabetItalian.indexOf('g') + 1);
      break;
    case 'h':
      positionsArray.push(alphabetItalian.indexOf('h') + 1);
      break;
    case 'i':
      positionsArray.push(alphabetItalian.indexOf('i') + 1);
      break;
    case 'l':
      positionsArray.push(alphabetItalian.indexOf('l') + 1);
      break;
    case 'm':
      positionsArray.push(alphabetItalian.indexOf('m') + 1);
      break;
    case 'n':
      positionsArray.push(alphabetItalian.indexOf('n') + 1);
      break;
    case 'o':
      positionsArray.push(alphabetItalian.indexOf('o') + 1);
      break;
    case 'p':
      positionsArray.push(alphabetItalian.indexOf('p') + 1);
      break;
    case 'q':
      positionsArray.push(alphabetItalian.indexOf('q') + 1);
      break;
    case 'r':
      positionsArray.push(alphabetItalian.indexOf('r') + 1);
      break;
    case 's':
      positionsArray.push(alphabetItalian.indexOf('s') + 1);
      break;
    case 't':
      positionsArray.push(alphabetItalian.indexOf('t') + 1);
      break;
    case 'u':
      positionsArray.push(alphabetItalian.indexOf('u') + 1);
      break;
    case 'v':
      positionsArray.push(alphabetItalian.indexOf('v') + 1);
      break;
    case 'z':
      positionsArray.push(alphabetItalian.indexOf('z') + 1);
      break;
    default:
      positionsArray.push(null); // Se il carattere non è presente nell'alfabeto italiano, aggiungi null all'array
  }
}

console.log(positionsArray);
