export function drawHole(htmlContainer) {
  const hole = document.createElement("div");
  hole.className = "holeRunningBelt";
  htmlContainer.appendChild(hole);
}

export function deleteHole(htmlContainer) {
  const holes = htmlContainer.querySelectorAll(".holeRunningBelt");
  if (holes.length > 0) {
      htmlContainer.removeChild(holes[holes.length - 1]);
  }
}

export function drawObject(htmlContainer, item) {
  const itemContainer = document.createElement("div");
  const _item = document.createElement("div");
  itemContainer.className = "itemInBeltContainer";
  _item.className = `${item.objectType}ObjectClass`;
  itemContainer.appendChild(_item);
  htmlContainer.appendChild(itemContainer);
}

export function deleteObject(htmlContainer, item){
  const className =  `${item.objectType}ObjectClass`;

  const holes = htmlContainer.querySelectorAll(`.${className}`);
  if (holes.length > 0) {
      htmlContainer.removeChild(holes[holes.length - 1]);
  }
}
