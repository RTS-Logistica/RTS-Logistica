
export class CentralConveroyBelt {
  constructor(url, container, connection, ArrayOfConveroyBelts, addItemTimer) {
    this.defaultSpeed = 3000;
    this._addItemTimer = (addItemTimer <= this.defaultSpeed)?this.defaultSpeed:addItemTimer; // suplanta al if / else
    this._rts = connection;
    this._container = container;
    this._customSpeed = 0;
    this._item = null;
    this._simpleConveroyBelts = ArrayOfConveroyBelts;
    connection.connect(url, () => {
      this.play();
    });
  }

  play() {
    if (this._customSpeed == 0) 
      this._customSpeed = this.defaultSpeed;
    delay(this._customSpeed).then(() => {
      for (let i = 0; i < this._simpleConveroyBelts.length; i++) 
        this._simpleConveroyBelts[i].play();
    });
    delay(this._addItemTimer).then(() => {
      this._simpleConveroyBelts[0].addItem(item);
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