import { centralCoveyerBelt } from './initializations.js'; 
import { DataParse } from "../peripherals/Elements/DataParse.js";

document.addEventListener('DOMContentLoaded', function() {
    const startButton = document.getElementById('start-button');
    const stopButton = document.getElementById('stop-button');
    const batchIdInput = document.getElementById('lote-id-input');
    let dataParse = null;
    let running = false;
    let indexUserData = 0;

    function runLoop() {
        if (!running) {
            return;
        }

        // el RTS tendria que DataBatch la data del lote
        centralCoveyerBelt.play(dataParse);
        indexUserData++;

        //*1
        requestAnimationFrame(runLoop);
    }

    startButton.addEventListener('click', function() {
        let batchId = parseInt(batchIdInput.value);

        if (batchId >= 1 && batchId <= 4) {
            if (!running) {
                running = true;
                runLoop(); 
            }
        } else {
            console.log('El batchId debe ser un número entre 1 y 4.');
        }
    });

    stopButton.addEventListener('click', function() {
        running = false; 
        console.log('El bucle se ha detenido.');
    });

    fetch('./batchData/DataBatch-ID1.json')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al cargar el archivo JSON');
            }
            return response.json();
        })
        .then(data => {
            // Aquí puedes trabajar con los datos obtenidos del JSON
            console.log(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
});




// *1: Método que le dice al navegador que ejecute una función específica antes del próximo repintado de 
//     la página. Es una manera eficiente de realizar animaciones y bucles continuos sin bloquear el hilo 
//     principal del navegador.