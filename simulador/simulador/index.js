var cinta;

document.addEventListener("DOMContentLoaded", function () {
    cinta = document.querySelector("#cinta");
    cinta.style.left = 0;
    document.getElementById("botonAccion").addEventListener('click', moverCinta);
    document.getElementById("botonAgregar").addEventListener('click', agregarCinta);
});

function moverCinta() {
    let contenidoCinta = document.getElementById("cinta").innerHTML;
    document.getElementById("cinta").innerHTML = `<div class="separacion">  </div>` + contenidoCinta;
}   

function agregarCinta() {
    let contenidoCinta = document.getElementById("cinta").innerHTML;
    document.getElementById("cinta").innerHTML = `<div class="sobre"></div>` + contenidoCinta;
}

