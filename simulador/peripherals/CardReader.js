import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";

export class CardReader{

    constructor(url, container, connection, converoyBelt, badReadTime){
        this._rts = connection;
        this._container = container;
        this._converoyBelt = converoyBelt
        this._badReadTime = badReadTime;
        this._badReadTimer = this._badReadTime;
        this.lastCardIndex = 0;
        this._connection = connection;
        this._cardCounter = 0;
        connection.connect(url, () => {});
        this.restartCardCounter();
    } 

    restartCardCounter() {
        this._cardCounter = 0;
    }

    getCardCounter() {
        return this._cardCounter;
    }

    badRead(){
        let randomNumber = '';
        for (let i = 0; i < 16; i++) {
            randomNumber += Math.floor(Math.random() * 10).toString();
        }
        return randomNumber;
    };
    
    addItem(data){
        if(this._badReadTimer = 0) {
            cardNumberRead = badRead();
            this._rts.send("Lectura incorrecta");
            this._converoyBelt.stop();
            this._badReadTimer = _badReadTime;
        }
        else {
            this._connection.send(data.UsersData.cardNumber);
            this._converoyBelt.addItem(data);
            displayMonitor(this._container, data.UsersData.cardNumber, "lector");
            document.getElementById("cardCounter").innerHTML = ++this._cardCounter;
        }
    };

    ping() {
        this._rts.send("ping card");
    }
}