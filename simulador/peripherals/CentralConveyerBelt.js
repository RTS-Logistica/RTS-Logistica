
export class CentralConveyerBelt {
  constructor(url, connection, ArrayOfConveyerBelts, addItemTimer, speed) {
    this.defaultSpeed = 3;
    this._addItemTimer = (addItemTimer <= this.defaultSpeed)?this.defaultSpeed:addItemTimer; // suplanta al if / else
    this._rts = connection;
    this._customSpeed = speed;
    this._simpleConveyerBelts = ArrayOfConveyerBelts;
    connection.connect(url, () => {
      this.play();
    });
  }

  play(itemIterator) {
    if (this._customSpeed == 0) 
      this._customSpeed = this.defaultSpeed;
    setInterval(() => {
      for (let i = 0; i < this._simpleConveyerBelts.length; i++) 
        this._simpleConveyerBelts[i].play();
    }, this._customSpeed);
    setInterval(() => {
      itemIterator.next();
      this._simpleConveyerBelts[0].addItem(itemIterator);
    }, this._addItemTimer);
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