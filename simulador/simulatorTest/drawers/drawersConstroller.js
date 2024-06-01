import {displayLectorMonitor, displayPritingMonitor} from "./displayDrawers.js";
import {drawCard, drawBrochure, drawEnvelope} from "./objectDrawers.js";

export function drawHole(htmlContainer) {
  const hole = document.createElement("div");
  hole.className = "hole-running-belt";
  htmlContainer.appendChild(hole);
}

export function deleteHole(htmlContainer) {
  const holes = htmlContainer.querySelectorAll(".hole-running-belt");
  if (holes.length > 0) {
      htmlContainer.removeChild(holes[holes.length - 1]);
  }
}

export function drawObject(htmlContainer, item, objectType) {
  if(objectType == "card") 
    drawCard(htmlContainer, item);
  else if(objectType == "brochure")
    drawBrochure(htmlContainer, item);
  else if(objectType == "envelope")
    drawEnvelope(htmlContainer, item);
}

export function deleteObject(htmlContainer, objectType){
  const className =`${objectType}-class-container`;

  const holes = htmlContainer.querySelectorAll(`.${className}`);
  if (holes.length > 0) {
      htmlContainer.removeChild(holes[holes.length - 1]);
  }
}

export function displayMonitor(htmlContainer, dataDisplay, monitorType){
  if(monitorType == "priting")
    displayPritingMonitor(htmlContainer, dataDisplay);
  else if(monitorType == "lector")
    displayLectorMonitor(htmlContainer, dataDisplay);
}
