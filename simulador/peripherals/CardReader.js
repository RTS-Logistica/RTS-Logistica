import { showInMonitor } from "../simulatorTest/drawers/cardLectorDrawers.js";
import BankCard from "../peripherals/Elements/BankCard.js";

export class CardReader{

    constructor(url, container, connection, converoyBelt, cardList){
        this._rts = connection;
        this._container = container;
        this._converoyBelt = converoyBelt
        this._cardList = cardList;
        this.timerOfBadReadTimer = 12;
        this.badReadTimer = this.timerOfBadReadTimer;
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
        if(this.badReadTimer = 0){
            cardNumberRead = this.badRead();
            this._rts.send("Lectura incorrecta");
            this._converoyBelt.stop();
            this.badReadTimer = timerOfBadReadTimer;
        }
        else{
            cardNumberRead = this.okRead();
            this._converoyBelt.addItem(new BankCard (data));
            showInMonitor(this._container, cardNumberRead);
        }
    };
}