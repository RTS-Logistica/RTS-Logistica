export class ConveroyBelt{
    _speed;
    // defaultSpeed
    // customSpeed

    constructor(url, connection, obj){
        this._connection=connection;
        this._speed = 3000;
        connection.connect(url, ()=> {this.play()})
    }

    sendError(){}

    setSpeed(speed){
        this._speed = speed;
    }
    // agregar huecos (play)
    // agregar objetos (me llama otra clase) - cuando llega al final (queue)
    play(item){
        if(_speed > 0){
            delay(_speed).then(() => {
                connection.send(item); //agrego obj, quito obj, <agrego el obj visual
            });
        }
        else
            connection.send("la cinta esta detenida")
    }
    stop(){
        this._speed = 0;
    }
}