import { DataParse } from "../peripherals/Elements/DataParse.js";
import { centralCoveyerBelt, cardReader, envelopePrinter, brochurePriter } from "../simulatorTest/initializations.js";
import WebSocketConnection from '../peripherals/webscketConnection.js';

export let running = false;
export let jsonBatchData;
let currentData;

export function stopSimulation() {
    running = false;
    centralCoveyerBelt.stop();
    document.getElementById("start-button").classList.remove("disabledBtn");
    document.getElementById("speed").classList.remove("disabledBtn");
    document.getElementById("maxBatchSize").classList.remove("disabledBtn");
    document.getElementById("lote-id-input").classList.remove("disabledBtn");
    document.getElementById("addItemMilliseconds").classList.remove("disabledBtn");
    cardReader.restartCardCounter();
    envelopePrinter.restartCardCounter();
    brochurePriter.restartCardCounter();
}

document.addEventListener('DOMContentLoaded', async function() {
    const startButton = document.getElementById('start-button');
    const stopButton = document.getElementById('stop-button');
    const batchIdInput = document.getElementById('lote-id-input');

    function runLoop() {
        if (!running) {
            return;
        }
        const url = 'ws://localhost:8080/batch';
        let connection = new WebSocketConnection();
        cardReader.restartCardCounter();
        connection.connect(url, () => {
            centralCoveyerBelt.setSpeed(parseInt(document.getElementById("speed").value));
            centralCoveyerBelt.setAddItemSpeed(parseInt(document.getElementById("addItemMilliseconds").value));
            jsonBatchData.usersData.length = parseInt(document.getElementById("maxBatchSize").value);
            connection.send(JSON.stringify(jsonBatchData));
            currentData = new DataParse(jsonBatchData, jsonBatchData.usersData.length);
            centralCoveyerBelt.play(currentData);
            document.getElementById("start-button").classList.add("disabledBtn");
            document.getElementById("speed").classList.add("disabledBtn");
            document.getElementById("maxBatchSize").classList.add("disabledBtn");
            document.getElementById("lote-id-input").classList.add("disabledBtn");
            document.getElementById("addItemMilliseconds").classList.add("disabledBtn");
        });
    }

    stopButton.addEventListener('click', async function() {
        let stopBtn = document.getElementById("stop-button");
        if(stopBtn.innerHTML == "STOP") { 
            centralCoveyerBelt.stop();  
            document.getElementById("stop-button").innerHTML = "RUN";
        } else {
            centralCoveyerBelt.play(currentData);
            document.getElementById("stop-button").innerHTML = "STOP";
        }
    });

    startButton.addEventListener('click', async function() {
        if (running) 
            return;
        let batchId = parseInt(batchIdInput.value);

        if (batchId >= 1 && batchId <= 4) {

            const requestOptions = {
                method: 'GET',
                headers: { 
                    "Content-Type": "application/json",
                },
                cache: 'default'
            };
            
            try {
                let response = await fetch(`https://localhost:7102/BatchController?BatchId=${batchId}`, requestOptions);
                
                if (response.ok) {
                    jsonBatchData = await response.json();
                } else {
                    console.error('Error:', response.statusText);
                }
            } catch (error) {
                console.error('Fetch error:', error);
            }
             
            running = true;
            runLoop(); 
        
        } else {
            console.log('El batchId debe ser un número entre 1 y 4.');
        }
    });

});