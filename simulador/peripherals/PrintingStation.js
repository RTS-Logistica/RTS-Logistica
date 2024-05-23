import Queue from "./Collections/Queue.js";
import ConveroyBelt  from "./ConveroyBelt.js";
import WebSocketConnection from "./webscketConnection.js";

class PrintingStation {
  printerQueue;

  constructor(url, connection, coveryorBelt) {
    this._connection = connection;
    this.printerQueue = new Queue();
    connection.connect(url, ()=> {this.print()})
  } 

  print(data) {
    this.printerQueue.enqueue(data);
    if (this.printerQueue.size() < 3)
        //llamar a la clase de nico para q lo muestre.
        console.log(data)                                                                                                                                                                         ;
    else
      this._connection.send("la cola esta llena");
  }

  usePriting(item){
    if(this.printerQueue.size() != 0)
      {
        let envelope = this.printerQueue.dequeue();
        envelope.addCard(item); //evaluar usar la clase Envelope o no
        new ConveroyBelt(url, new WebSocketConnection());
      }
    else
      this._connection.send("la cola esta vacia");
  }

  pause(message) {}
}