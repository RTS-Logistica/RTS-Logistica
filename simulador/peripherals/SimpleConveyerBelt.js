import Queue from "./Collections/Queue.js";
import { drawObject, deleteObject, drawHole, deleteHole } from "../simulatorTest/drawers/drawersConstroller.js";
import { envelopePrinter } from "../simulatorTest/initializations.js";
import { stopSimulation, running, jsonBatchData } from "../simulatorTest/simulator.js";

export class SimpleConveyerBelt {
  constructor(url, container, connection,
              widget, maxLenght, centralCoveroyBelt, typeObjectDraw)
  {
    this._rts = connection;
    this._container = container;
    this._centralCoveroyBelt = centralCoveroyBelt;
    this._widget = widget;
    this._maxLenght = maxLenght;
    this._item = null;
    this._typeObjectDraw = typeObjectDraw;
    this.objectQueue = new Queue();
    //connection.connect(url, () => {});
  }

  addItem(item) {
    if (this._item != null) {
      this._rts.send("Desincronizacion");
      console.log("Desincronizacion");
    } 
    else 
      this._item = item;
  }

  play() {
    if (this._item != null) {
      this.objectQueue.enqueue(this._item);
      this.objectQueue.enqueue(0);
      this.objectQueue.enqueue(0);
      this.objectQueue.enqueue(0);
      this.objectQueue.enqueue(0);
      drawObject(this._container, this._item, this._typeObjectDraw);
      this._item = null;
    } 
    else {
      this.objectQueue.enqueue(0);
      drawHole(this._container);
    }

    if (this.objectQueue.size() >= this._maxLenght) {
      let item = this.objectQueue.dequeue();
      if (item != 0){
        if(this._widget != null)
          this._widget.addItem(item);
        deleteObject(this._container, this._typeObjectDraw);
        this.objectQueue.dequeue();
        this.objectQueue.dequeue();
        this.objectQueue.dequeue();
        this.objectQueue.dequeue();
      } 
      else{
        deleteHole(this._container);
      }  
    }
    if(this._widget != null)
      this._widget.ping();
    else if(running && envelopePrinter.getCardCounter() >= jsonBatchData.usersData.length)
      stopSimulation();
  }

  stop() {
    this._centralCoveroyBelt.stop();
  }
}