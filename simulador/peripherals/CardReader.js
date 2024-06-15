import { displayMonitor } from "../simulatorTest/drawers/drawersConstroller.js";
import { togglePauseSimulation } from "../simulatorTest/simulator.js";

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
        connection.connect(url, (message) => { 
            if(message.data == "correct number")
                this._waitingForReadResponse = false; 
            else {
                alert("La cinta se detiene mientras se relee el numero de tarjeta, el valor enviado era incorrecto.");
                this._connection.send(this._currentCard.UsersData.cardNumber);
            }
        });
        this.restartCardCounter();
    } 

    restartCardCounter() {
        this._cardCounter = 0;
    }

    getCardCounter() {
        return this._cardCounter;
    }

    badRead(){
        let randomNumber = '1';
        for (let i = 0; i < 15; i++) {
            randomNumber += Math.floor(Math.random() * 10).toString();
        }
        return randomNumber;
    };
    
    async sleep(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    async addItem(data){
        if(this._cardCounter > 0 &&this._cardCounter % this._badReadTime == 0) {
            this._connection.send(this.badRead());
            this._currentCard = data;
        } else
            this._connection.send(data.UsersData.cardNumber);
        this._waitingForReadResponse = true;
        togglePauseSimulation();
        while(this._waitingForReadResponse)
            await this.sleep (100);
        togglePauseSimulation();
        this._converoyBelt.addItem(data);
        displayMonitor(this._container, data.UsersData.cardNumber, "lector");
        document.getElementById("cardCounter").innerHTML = ++this._cardCounter;
    };

    ping() {
        this._rts.send("ping card");
    }
}