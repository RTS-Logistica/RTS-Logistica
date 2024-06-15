import Console from "../peripherals/console.js"
import WebSocketConnection from "../peripherals/webscketConnection.js";
                               
document.addEventListener('DOMContentLoaded', function() {
    let domain = 'ws://localhost:8080';
    let batchConsole = document.getElementById("batchConsole");
    let cardConsole = document.getElementById("cardConsole");
    
    new Console(domain + '/card', new WebSocketConnection(), cardConsole, 'cardConsole');
    new Console(domain + '/batch', new WebSocketConnection(), batchConsole, 'batchConsole');
});