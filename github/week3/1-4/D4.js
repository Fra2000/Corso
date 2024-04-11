
const tabellacompleta= function(){
const tablelement=document.getElementById('tabella');
for (let i=0; i<90; i++) {
    const cella=document.createElement('div');
     cella.classList.add('cella');
     cella.textContent=i+1;
     tablelement.appendChild(cella);
}}
tabellacompleta()

const Random =function() {
    butrandom=document.querySelector('button');
    butrandom=Math.ceil(Math.random()*90);
    
}
Random()
