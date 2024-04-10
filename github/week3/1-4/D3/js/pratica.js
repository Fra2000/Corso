window.onload= function() {
    let form=document.querySelector('form')
    form.addEventListener('submit', handlesubmit);
}
const handlesubmit=function(a)  {
    a.preventDefault();
}

function lista(event) {
 let list=document.querySelector('ul').value;  
 const li=document.createElement('li');
 li.textContent=list;
 document.querySelector('ul').appendChild('li');
}