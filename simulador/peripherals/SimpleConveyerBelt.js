import Queue from "./Collections/Queue.js";
import { drawObject, deleteObject, drawHole, deleteHole } from "../simulatorTest/drawers/drawersConstroller.js";

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
    connection.connect(url, () => {});
  }

  isReady() {}

  addItem(item) { // retorne tru o false | retorne si puede recibir o no --> ready()
    if (this._item) {
      this._rts.send("Desincronizacion");
      alert("Desincronizacion");
    } 
    else 
      this._item = item;
  }

  play() {
    if (this._item != null) {
      this.objectQueue.enqueue(1);
      drawObject(this._container, this._item, this._typeObjectDraw);
    } 
    else {
      this.objectQueue.enqueue(0);
      drawHole(this._container);
    }

    if (this.objectQueue.size() == this._maxLenght) {
      let item = this.objectQueue.dequeue();
      if (item != 0){
        this._widget.addItem(item);
        deleteObject(this._container, this._item, _typeObjectDraw);
      } 
      else{
        deleteHole(this._container);
      }  
    }
  }

  stop() {
    this._centralCoveroyBelt.stop();
  }
}




/// VA A SER EL CENTRALBELT --> Se conectoa con el RTS
// posta donde ingrese el num de lote (input) junto con el boton RUN --> callback
// connection.connect(url, () => {
//   this.play(); --> setear un delay cada x cant seg y meta las tarjetas a la cinta.
// });

// la cinta tenga un getter de la velocidad

// method --> boton() : envia un dato al RTS