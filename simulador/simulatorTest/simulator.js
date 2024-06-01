import { centralCoveyerBelt } from './initializations.js'; 
import { DataParse } from "../peripherals/Elements/DataParse.js";

document.addEventListener('DOMContentLoaded', async function() {
    const startButton = document.getElementById('start-button');
    const stopButton = document.getElementById('stop-button');
    const batchIdInput = document.getElementById('lote-id-input');
    let running = false;


    function runLoop(jsonBatchData) {
        if (!running) {
            return;
        }

        // el RTS tendria que DataBatch la data del lote
        centralCoveyerBelt.play(new DataParse(jsonBatchData, jsonBatchData.usersData.length));

    }

    startButton.addEventListener('click', async function() {
        let batchId = parseInt(batchIdInput.value);

        if (batchId >= 1 && batchId <= 4) {

            const requestOptions = {
                method: 'GET',
                headers: { 
                    "Content-Type": "application/json",
                },
                cache: 'default'
            };
            
            let result = [];
            try {
                let response = await fetch(`https://localhost:7102/BatchController?BatchId=${batchId}`, requestOptions);
                
                if (response.ok) {
                    result = await response.json();
                } else {
                    console.error('Error:', response.statusText);
                }
            } catch (error) {
                console.error('Fetch error:', error);
            }
            
            if (!running) {
                running = true;
                runLoop(result); 
            }
        } else {
            console.log('El batchId debe ser un número entre 1 y 4.');
        }
    });

    stopButton.addEventListener('click', function() {
        running = false; 
        console.log('El bucle se ha detenido.');
    });
});