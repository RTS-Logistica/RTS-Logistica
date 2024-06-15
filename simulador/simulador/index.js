import { eyeCreator } from "./creator/eyeCreator.js";
import { queueCreator } from "./creator/queueCreator.js";
import { monitorCreator } from "./creator/monitorCreator.js";
var cinta;
var scanner;
var pBrochure;
var pEnvelope;
var texto = `Perez Juan Calle falsa 123 Berazategui. 1885 Buenos Aires`;
document.addEventListener("DOMContentLoaded", function () {
  cinta = document.querySelector("#cinta");
  scanner = document.querySelector(".lectorCardNumber");
  pBrochure = document.querySelector(".printerBrochure");
  pEnvelope = document.querySelector(".printerEnvelope");
  cinta.style.left = 0;
  eyeCreator.creator(scanner);
  eyeCreator.creator(pBrochure);
  eyeCreator.creator(pEnvelope);
  monitorCreator.creator(pBrochure);
  monitorCreator.creator(pEnvelope);
  showMonitorText(pBrochure, texto);
  showMonitorText(pEnvelope, texto);
  const queueB = new queueCreator(pBrochure, "./images/brochure.jpg");
  const queueE = new queueCreator(pEnvelope, "./images/envelope.png");
  document.getElementById("botonAccion").addEventListener("click", () => {
    moverCinta();
  });
  document
    .getElementById("botonAgregar")
    .addEventListener("click", agregarCinta);
  document.querySelector(".btnReadNumber").addEventListener("click", () => {
    let numero = document.querySelector(".inpNumber").value;
    readCardNumber(numero);
  });
  showBeltStatus("La cinta esta funcionando");
  document.querySelector(".btnAddBrochure").addEventListener("click", () => {
    queueB.addToQueue();
  });
  document.querySelector(".btnDeleteBrochure").addEventListener("click", () => {
    queueB.deleteFromQueue();
  });
  document.querySelector(".btnAddEnvelope").addEventListener("click", () => {
    queueE.addToQueue();
  });
  document.querySelector(".btnDeleteEnvelope").addEventListener("click", () => {
    queueE.deleteFromQueue();
  });
  document.querySelector(".btnPaintLector").addEventListener("click", () => {
    changeBorderColor(scanner, "green");
  });
  document.querySelector(".btnPaintLector").addEventListener("mouseout", () => {
    changeBorderColor(scanner, "red");
  });
  document
    .querySelector(".btnPaintPrinterBrochure")
    .addEventListener("click", () => {
      changeBorderColor(pBrochure, "green");
    });
  document
    .querySelector(".btnPaintPrinterBrochure")
    .addEventListener("mouseout", () => {
      changeBorderColor(pBrochure, "red");
    });
  document
    .querySelector(".btnPaintPrinterEnvelope")
    .addEventListener("click", () => {
      changeBorderColor(pEnvelope, "green");
    });
  document
    .querySelector(".btnPaintPrinterEnvelope")
    .addEventListener("mouseout", () => {
      changeBorderColor(pEnvelope, "red");
    });
});

function moverCinta() {
  let contenidoCinta = document.getElementById("cinta").innerHTML;
  document.getElementById("cinta").innerHTML =
    `<div class="separacion"></div>` + contenidoCinta;
}

function agregarCinta() {
  let contenidoCinta = document.getElementById("cinta").innerHTML;
  document.getElementById("cinta").innerHTML =
    `<div class="card"></div>` + contenidoCinta;
}

function readCardNumber(cardNumber) {
  var number = document.querySelector(".showCardNumber");
  number.innerText = cardNumber;
}
function changeBorderColor(container, color) {
  var eye = container.querySelector("#eye");
  container.style.borderColor = color;
  eye.style.color = color;
}

function showBeltStatus(message) {
  var status = document.querySelector(".showBeltStatus");
  status.innerText = message;
}
function changeImage(image) {
  var beltThree = document.getElementById("beltThree");
  beltThree.innerHTML += image;
}
function showMonitorText(container, message) {
  var textOfMonitor = container.querySelector(".textOfMonitor");
  textOfMonitor.innerText = message;
}
