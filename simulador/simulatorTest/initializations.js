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
const urlConnection = 'ws://localhost:8080';
const conveyerBeltSpeed = parseInt(document.getElementById("speed").value);
const timerToAddItemOnConveyerBelt = parseInt(document.getElementById("addItemMilliseconds").value);;
const maxSizeElementOnConveyerBelt = 9;
const badReadTimer = 12;
const typeObjectDraw = ['card', 'brochure', 'envelope'];
const envelopePrintredQueueSize = 4;
const brochurePrintredQueueSize = 3;

// ------ PERIPHERALS INSTANCES ------ //
const centralCoveyerBelt = new CentralConveyerBelt(urlConnection + "/playConveyerBelt", new WebSocketConnection(), null, timerToAddItemOnConveyerBelt, conveyerBeltSpeed);
const fourthCoveyerBelt = new SimpleConveyerBelt(urlConnection + "/b", fourthCoveyerBeltBeltContainer, new WebSocketConnection(), null, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[2]);
const envelopePrinter = new PrintingStation(urlConnection + "/envelopePrinterStation", envelopeContainer, new WebSocketConnection(), fourthCoveyerBelt, typeObjectDraw[2], envelopePrintredQueueSize);
const thirdCoveyerBelt = new SimpleConveyerBelt(urlConnection + "/c", thirdCoveyerBeltContainer, new WebSocketConnection(), envelopePrinter, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[1]);  
const brochurePriter = new PrintingStation(urlConnection + "/brochurePrinterStation", brochurePrinterContainer, new WebSocketConnection(), thirdCoveyerBelt, typeObjectDraw[1], brochurePrintredQueueSize);
const secondCoveyerBelt = new SimpleConveyerBelt(urlConnection + "/d", secondCoveyerBeltContainer, new WebSocketConnection(), brochurePriter, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[0]);  
const cardReader = new CardReader(urlConnection + "/cardReader", cardLectorContainer, new WebSocketConnection(), secondCoveyerBelt, badReadTimer);
const firstCoveyerBelt = new SimpleConveyerBelt(urlConnection + "/e", firstCoveyerBeltContainer, new WebSocketConnection(), cardReader, maxSizeElementOnConveyerBelt, centralCoveyerBelt, typeObjectDraw[0]);

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