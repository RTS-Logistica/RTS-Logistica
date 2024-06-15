import { batchDataIterator } from "../simulatorTest/simulator.js";

export class CentralConveyerBelt {
  constructor(url, connection, ArrayOfConveyerBelts, addItemTimer, speed) {
    this.defaultSpeed = speed;
    this._addItemTimer = (addItemTimer <= this.defaultSpeed)?this.defaultSpeed:addItemTimer;
    this._rts = connection;
    this._customSpeed = speed;
    this._simpleConveyerBelts = ArrayOfConveyerBelts;
    connection.connect(url, () => {
      this.play();
    });
  }

  play() {
    if (this._customSpeed == 0) 
      this._customSpeed = this.defaultSpeed;
    this._playInterval = setInterval(() => {
      for (let i = 0; i < this._simpleConveyerBelts.length; i++) 
        this._simpleConveyerBelts[i].play();
    }, this._customSpeed);
    this._addInterval = setInterval(() => {
      if(batchDataIterator.hasNext())   
        this._simpleConveyerBelts[0].addItem(batchDataIterator.get());
    }, this._addItemTimer);
  }

  setAddItemSpeed(milliseconds) {
    if(speed < 0)
      console.log("La velocidad no puede ser menor que 0");
    else
      this._addItemTimer = parseInt(milliseconds);
  }

  setSpeed(speed) {
    if(speed < 0)
      console.log("La velocidad no puede ser menor que 0");
    else {
      this._customSpeed = parseInt(speed);
      this.defaultSpeed = this._customSpeed;
    }
  }

  stop() {
    this._customSpeed = 0;
    if(this._playInterval)
      clearInterval(this._playInterval);
    if(this._addInterval)
      clearInterval(this._addInterval);
  }
}