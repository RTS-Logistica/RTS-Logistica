import Queue from "./Collections/Queue.js";
import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";
import { drawObject, deleteObject } from "../simulatorTest/drawers/drawersConstroller.js";
import { togglePauseSimulation } from "../simulatorTest/simulator.js";

export class PrintingStation {
  paperElem;

  constructor(url, container, connection, coveryorBelt, typeObjectDraw, printedQueuesize) {
    this._rts = connection;
    this._container = container;
    this._printedQueuesize = printedQueuesize;
    this._printerQueue = new Queue();
    this.alreadyPrintedQueue = new Queue();
    this._coveryotrBelt = coveryorBelt;
    this._typeObjectDraw = typeObjectDraw;
    this._cardCounter = 0;
    this._delayedPrinter = 0;
    connection.connect(url, (message) => {this.addToPrinterQueue(message.data)});
  }

  restartCardCounter() {
    this._cardCounter = 0;
  }

  getCardCounter() {
    return this._cardCounter;
  }

  addToPrinterQueue(data) {
    let fullAlreadyPrintedQueue = this.alreadyPrintedQueue.size() >= this._printedQueuesize;
    this._printerQueue.enqueue(data);
    if (fullAlreadyPrintedQueue)
      this._rts.send("La pila de papeles impresos esta llena.");
    else
      this.print();
  }
  
  print() {
    if(this._printerQueue.size() == 0)
      this._rts.send("La cola de impresion esta vacia. No hay nada para imprimir.");
    else {
      let forPrint = this._printerQueue.dequeue();
      let printed = JSON.parse(forPrint);
      this.alreadyPrintedQueue.enqueue(printed);
      drawObject(this._container.querySelector(".printerdsQueue"), printed, this._typeObjectDraw);
    }
  }

  addItem() {
    if (this.alreadyPrintedQueue.size() != 0) {
      //displayMonitor(this._container, data, "priting");
      if(this.alreadyPrintedQueue.size() <= 0)
        this._rts.send("Sin papel");
      else {
        let data = this.alreadyPrintedQueue.dequeue();
        this._coveryotrBelt.addItem(data);
        deleteObject(this._container.querySelector(".printerdsQueue"), this._typeObjectDraw);
        this._cardCounter++;
        if(--this._delayedPrinter == 0) {
          alert(`A la impresora Se detiene la cinta hasta que se imprime un ${this._typeObjectDraw}`);
          this._container.querySelector(".printerdsQueue").classList.remove("hidden");
        }
        if(this._printerQueue.size() > 0) {
          this._delayedPrinter = 3;
          this.print();
          this._container.querySelector(".printerdsQueue").classList.add("hidden");
        }
      }
    } else {
      this._rts.send("No hay impresiones listas.");
      togglePauseSimulation();
    }
  }

  ping() {
    this._rts.send("ping printer");
  }
}
