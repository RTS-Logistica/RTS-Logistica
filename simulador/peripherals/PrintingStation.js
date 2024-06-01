import Queue from "./Collections/Queue.js";
import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";

export class PrintingStation {
  paperElem;

  constructor(url, container, connection, coveryorBelt) {
    this._rts = connection;
    this._container = container;
    this.printerQueue = new Queue();
    this.alreadyPrintedQueue = new Queue();
    this._coveryotrBelt = coveryorBelt;
    connection.connect(url, () => {});
  }

  print(data) {
    this.printerQueue.enqueue(data);   
    let forPrint = this.printerQueue.dequeue();
    if (this.alreadyPrintedQueue.size() >= 3)
      this._rts.send("la cola esta llena");
    else this.alreadyPrintedQueue.enqueue(forPrint);
  }

  addItem(item) {
    if (this.alreadyPrintedQueue.size() != 0) {
      let data = this.alreadyPrintedQueue.dequeue();
      displayMonitor(this._container, data, "priting");
      _coveryotrBelt.addItem(container, paper);
    } else {
      this._rts.send("la cola esta vacia");
      _coveryotrBelt.stop();
    }
  }
}
