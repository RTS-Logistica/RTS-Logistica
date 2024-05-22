export class queueCreator{
    constructor(container, imageSrc){
        this.container=container;
        this.element=`<div class="element"><img src="${imageSrc}"></div>`
        this.queue=container.querySelector(".queue")
    }
    addToQueue(){
        this.queue.innerHTML+=this.element;
    }
    deleteFromQueue(){
        var imagen=this.queue.querySelector(".element")
        this.queue.removeChild(imagen)
    }
}