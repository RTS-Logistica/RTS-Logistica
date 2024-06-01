// ------ PERIPHERALS ------ //
import { SimpleConveyerBelt } from "../peripherals/SimpleConveyerBelt.js";
import { CentralConveyerBelt } from "../peripherals/CentralConveyerBelt.js";
import { CardReader } from "../peripherals/CardReader.js";
import { PrintingStation } from "../peripherals/PrintingStation.js";
import WebSocketConnection from "../peripherals/webscketConnection.js";

// ------ HTML CONTAINERS ------ //
const firstCoveyerBeltContainer = document.getElementById('conveyer-belt-1');
const secondCoveyerBeltContainer = document.getElementById('conveyer-belt-2');
const thirdCoveyerBeltContainer = document.getElementById('conveyer-belt-3');
const fourthCoveyerBeltBeltContainer = document.getElementById('conveyer-belt-4');
const cardLectorContainer = document.getElementById('card-lector');
const brochurePrinterContainer = document.getElementById('priting-station-box-1');
const envelopeContainer = document.getElementById('priting-station-box-2');

// ------ SIMULATION VARIABLES ------ //
const urlConnection = 'ws://127.0.0.1:5500';
const conveyerBeltSpeed = 1000;
const timerToAddItemOnConveyerBelt = 3000;
const maxSizeElementOnConveyerBelt = 5;
const arrayOfCardsNumbers = ['1', '2', '3', '4', '5', '1', '2', '3', '4', '5', '1', '2', '3', '4', '5', '1', '2', '3', '4', '5'];
const badReadTimer = 12;
const typeObjectDraw = ['card', 'brochure', 'envelope'];

// ------ PERIPHERALS INSTANCES ------ //
const centralCoveyerBelt = new CentralConveyerBelt(urlConnection, new WebSocketConnection(), null, timerToAddItemOnConveyerBelt, conveyerBeltSpeed);
const fourthCoveyerBelt = new SimpleConveyerBelt(urlConnection, fourthCoveyerBeltBeltContainer, new WebSocketConnection(), null, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[2]);
const envelopePrinter = new PrintingStation(urlConnection, envelopeContainer, new WebSocketConnection(), fourthCoveyerBelt);
const thirdCoveyerBelt = new SimpleConveyerBelt(urlConnection, thirdCoveyerBeltContainer, new WebSocketConnection(), envelopePrinter, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[1]);  
const brochurePriter = new PrintingStation(urlConnection, brochurePrinterContainer, new WebSocketConnection(), thirdCoveyerBelt);
const secondCoveyerBelt = new SimpleConveyerBelt(urlConnection, secondCoveyerBeltContainer, new WebSocketConnection(), brochurePriter, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[0]);  
const cardReader = new CardReader(urlConnection, cardLectorContainer, new WebSocketConnection(), secondCoveyerBelt, arrayOfCardsNumbers, badReadTimer);
const firstCoveyerBelt = new SimpleConveyerBelt(urlConnection, firstCoveyerBeltContainer, new WebSocketConnection(), cardReader, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[0]);

const arrayOfCoveyerBeltys = [firstCoveyerBelt, secondCoveyerBelt, thirdCoveyerBelt, fourthCoveyerBelt];
centralCoveyerBelt._simpleConveyerBelts = arrayOfCoveyerBeltys;

// ------ EXPORTS ------ //
export {
    firstCoveyerBelt,
    secondCoveyerBelt,
    thirdCoveyerBelt,
    fourthCoveyerBelt,
    centralCoveyerBelt,
    cardReader,
    brochurePriter,
    envelopePrinter
};