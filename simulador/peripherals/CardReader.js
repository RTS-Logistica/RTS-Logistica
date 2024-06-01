import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";

export class CardReader{

    constructor(url, container, connection, converoyBelt, cardList, badReadTime){
        this._rts = connection;
        this._container = container;
        this._converoyBelt = converoyBelt
        this._cardList = cardList;
        this._badReadTime = badReadTime;
        this._badReadTimer = this._badReadTime;
        this.lastCardIndex = 0;
        connection.connect(url, () => {});
    }
    okRead(){
        let cardNumber = this._cardList[this.lastCardIndex].cardNumber;
        this.lastCardIndex++;
        return cardNumber;
    }
    badRead(){
        let randomNumber = '';
        for (let i = 0; i < 16; i++) {
            randomNumber += Math.floor(Math.random() * 10).toString();
        }
        return randomNumber;
    };
    
    addItem(data){
        if(this._badReadTimer = 0){
            cardNumberRead = badRead();
            this._rts.send("Lectura incorrecta");
            this._converoyBelt.stop();
            this._badReadTimer = _badReadTime;
        }
        else{
            cardNumberRead = okRead();
            this._converoyBelt.addItem(data);
            displayMonitor(this._container, cardNumberRead, "lector");
        }
    };
}