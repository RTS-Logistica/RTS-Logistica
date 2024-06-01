
export class CentralConveyerBelt {
  constructor(url, connection, ArrayOfConveyerBelts, addItemTimer, speed) {
    this.defaultSpeed = 3000;
    this._addItemTimer = (addItemTimer <= this.defaultSpeed)?this.defaultSpeed:addItemTimer; // suplanta al if / else
    this._rts = connection;
    this._customSpeed = speed;
    this._simpleConveyerBelts = ArrayOfConveyerBelts;
    connection.connect(url, () => {
      this.play();
    });
  }

  play(item) {
    if (this._customSpeed == 0) 
      this._customSpeed = this.defaultSpeed;
    delay(this._customSpeed).then(() => {
      for (let i = 0; i < this._simpleConveyerBelts.length; i++) 
        this._simpleConveyerBelts[i].play();
    });
    delay(this._addItemTimer).then(() => {
      this._simpleConveyerBelts[0].addItem(item);
    });
  } 

  setSpeed(speed) {
    if(speed < 0)
      console.log("La velocidad no puede ser menor que 0");
    else
      this._customSpeed = parseInt(speed);
  }

  stop() {
    this._customSpeed = 0;
  }
}