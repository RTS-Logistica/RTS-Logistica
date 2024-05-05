export default class WebSocketConnection {

    connect(url, onmessageCallback){
        this._url = url;
        this.socket !== undefined && this.socket.close();
        this.socket = new WebSocket(url); 
        this.socket.onmessage = onmessageCallback; 
        this.socket.onclose = (e) => { this.connect(this._url, this.socket.onmessage); };
    }

    disconnect(){
        this.socket.close();
    }

    send(message) { 
        if (this.socket.readyState === 1)
            this.socket.send(message); 
        else if (this.socket.readyState !== 0) {
            this.connect(this._url, this.socket.onmessage);
            this.send(message);
        }
    }

}