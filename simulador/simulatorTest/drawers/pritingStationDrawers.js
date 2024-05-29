export function showInMonitor(htmlContainer, elemData) {
    const monitor = htmlContainer.querySelector(".monitorText");
    const name = document.createElement('p');
    name.textContent = `${elemData.name} ${elemData.surname}`;
    const address = document.createElement('p');
    address.textContent = `${elemData.address}`;
    const zip = document.createElement('p');
    zip.textContent = `ZIP : ${elemData.zip}`;
    monitor.appendChild(name);
    monitor.appendChild(address);
    monitor.appendChild(zip);
  }
  
export function drawElement(htmlContainer, elemType) { 
    const element = document.createElement('div');
    if (elemType == "A4") {
      element.className = 'tagPaper';
    }
    if (elemType == "Envelope") {
      element.className = 'EnvelopePaper';
    }
    htmlContainer.appendChild(element);
  }

  export function deleteElement(htmlContainer, elemType) { 
    const className = "";
    if (elemType == "A4") {
      className = 'tagPaper';
    }
    if (elemType == "Envelope") {
      className = 'EnvelopePaper';
    }
    const elements = htmlContainer.querySelectorAll(`.${className}`);
    if (elements.length > 0) {
        htmlContainer.removeChild(elements[elements.length - 1]);
    }
  }
