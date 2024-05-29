import CoveroyBelt from "../peripherals/ConveroyBelt.js";
import PrintingStation from "../peripherals/PrintingStation.js";
import WebSocketConnection from "../connection/webscketConnection.js";
                               
document.addEventListener('DOMContentLoaded', function() {
    let domain = 'ws://localhost:8080';
    const secondBeltObject = document.querySelector('#coveryoreBelt-2');
    
    const fourBelt = new CoveroyBelt(domain, new WebSocketConnection(), null);
    const envelopePrinter = new PrintingStation(domain, new WebSocketConnection(), fourBelt, "Envelope");
    const thridBelt = new CoveroyBelt(domain, new WebSocketConnection(), envelopePrinter);
    const tagPrinter = new PrintingStation(domain, new WebSocketConnection(), thridBelt, "A4");
    const secondBelt = new CoveroyBelt(domain, secondBeltObject,  new WebSocketConnection(), tagPrinter);
});