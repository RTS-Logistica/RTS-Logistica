export class monitorCreator{
    static creator(container){
        let monitor=
        `<div class="monitor">
            <img src="./images/monitor.png" class="monitorImage">
            <div class="textOfMonitor">
            </div>
        </div>`
        container.innerHTML += monitor;
    }
}