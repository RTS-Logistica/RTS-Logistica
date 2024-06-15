import Queue from "./Collections/Queue.js";
import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";
import { drawObject, deleteObject } from "../simulatorTest/drawers/drawersConstroller.js";

export class PrintingStation {
  paperElem;

  constructor(url, container, connection, coveryorBelt, typeObjectDraw, printedQueuesize) {
    this._rts = connection;
    this._container = container;
    this._printedQueuesize = printedQueuesize;
    this.printerQueue = new Queue();
    this.alreadyPrintedQueue = new Queue();
    this._coveryotrBelt = coveryorBelt;
    this._typeObjectDraw = typeObjectDraw;
    this._cardCounter = 0;
    connection.connect(url, (message) => {this.print(message.data)});
  }

  restartCardCounter() {
    this._cardCounter = 0;
  }

  getCardCounter() {
    return this._cardCounter;
  }

  print(data) {
    this.printerQueue.enqueue(data);   
    let forPrint = this.printerQueue.dequeue();
    if (this.alreadyPrintedQueue.size() >= this._printedQueuesize) {
      this._rts.send("la cola esta llena");
      //alert("la cola esta llena");
    } else {
      let printed = JSON.parse(forPrint);
      this.alreadyPrintedQueue.enqueue(printed);
      drawObject(this._container.querySelector(".printerdsQueue"), printed, this._typeObjectDraw);
    }
  }

  addItem(item) {
    if (this.alreadyPrintedQueue.size() != 0) {
      //displayMonitor(this._container, data, "priting");
      if(this.alreadyPrintedQueue.size() <= 0)
        this._rts.send("Sin papel");
      else {
        let data = this.alreadyPrintedQueue.dequeue();
        this._coveryotrBelt.addItem(data);
        deleteObject(this._container.querySelector(".printerdsQueue"), this._typeObjectDraw);
        this._cardCounter++;
      }
    } else {
      this._rts.send("la cola esta vacia");
      this._coveryotrBelt.stop();
    }
  }

  ping() {
    this._rts.send("ping printer");
  }
}
