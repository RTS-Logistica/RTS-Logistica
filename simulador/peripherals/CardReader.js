export class CardReader{
    T;
    constructor(connection){
        this.connection=connection;
        this.validNumbers=[];
        this.lastCardIndex=0;
    }
    OkRead(){
        this.connection.Send(this.validNumbers[this.lastCardIndex]);
        this.lastCardIndex++;
    }
    BadRead(){};
    SetSpeed(speed){};
    Play(speed){};
    Stop(speed){};
    Connect(){
        this.connection.Connect();
    }
    Disconnect(){
        this.connection.Disconnect();
    } 
}