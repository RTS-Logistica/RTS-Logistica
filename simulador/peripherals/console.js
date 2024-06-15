export default class Console {
    constructor(url, connection, container, consoleId) {
        container.innerHTML = ` 
            <div id="${consoleId}">
                <div class="consoleContainer">
                    <textarea class='console' rows='10' cols='50'></textarea> 
                </div>
                <div class="queryContainer">
                    <input class='query'></input> 
                    <button class='send'>Enviar Lote</button>
                </div>
            </div>
        `
        this._console = container.querySelector('.console');
        this._query = container.querySelector('.query');
        this._connection = connection;
        let self = this;

        this.write('Conectando...');
        connection.connect(url, (message)=> {self.write(message.data)});
        this._query.addEventListener("keyup", function(event) {
            if (event.keyCode === 13) {
                self.send();
            }
        });            
        container.querySelector('.send')
            .addEventListener('click', function(){self.send()});
    }
    
    send() {  
        this._connection.send(this._query.value);
        this._console.value = "";
    }

    write(mensaje) { 
        this._console.textContent += mensaje.toString() + '\n';
        this._console.scrollTop = this._console.scrollHeight;
    }

    getQuery() {
        return this._query;
    }
}