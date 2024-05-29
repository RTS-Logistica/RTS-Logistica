import Queue from "./Collections/Queue.js";
import Brochure from "./Elements/Brochure.js";
import Envelope from "./Elements/Envelope.js";
import { drawElement, showInMonitor } from "./elementFunctions.js";
import { deleteElement } from "../simulatorTest/drawers/pritingStationDrawers.js";

export class PrintingStation {
  paperElem;

  constructor(url, connection, container, coveryorBelt, typePaper) {
    this._rts = connection;
    this._container = container;
    this.printerQueue = new Queue();
    this.alreadyPrintedQueue = new Queue();
    this._typePaper = typePaper;
    this._coveryotrBelt = coveryorBelt;
    connection.connect(url + "/fullQueue", () => {});
  }

  print(data) {
    if (this._typePaper == "A4") 
      paperElem = new Brochure(data);
    else if (_typePaper == "Envelope") 
      paperElem = new Envelope(data);
    this.printerQueue.enqueue(paperElem);   
    let forPrint = this.printerQueue.dequeue();
    drawElement(this._container, this._typePaper);
    if (this.alreadyPrintedQueue.size() >= 3)
      this._rts.send("la cola esta llena");
    else this.alreadyPrintedQueue.enqueue(forPrint);
  }

  addItem(item) {
    if (this.alreadyPrintedQueue.size() != 0) {
      let paper = this.alreadyPrintedQueue.dequeue();
      paper.addItem(item);
      showInMonitor(this._container, paper);
      deleteElement(this._container, this._typePaper)
      _coveryotrBelt.addItem(container, paper);
    } else {
      this._rts.send("la cola esta vacia");
      _coveryotrBelt.stop();
    }
  }
}
