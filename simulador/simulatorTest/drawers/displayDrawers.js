export function displayLectorMonitor(container, numberToShow) {
  const monitor = container.querySelector(".monitor-text");
  let cardNumber = monitor.querySelector("p");
  if(!cardNumber)
    cardNumber = document.createElement("p");
  cardNumber.textContent = `${numberToShow}`;
  monitor.appendChild(cardNumber);
}

export function displayPritingMonitor(htmlContainer, elemData) {
  const monitor = htmlContainer.querySelector(".monitor-text");
  const name = document.createElement('p');
  name.textContent = `${elemData.userName} ${elemData.userSurname}`;
  const address = document.createElement('p');
  address.textContent = `${elemData.address()}`;
  const zip = document.createElement('p');
  zip.textContent = `ZIP : ${elemData.zipCode}`;
  monitor.appendChild(name);
  monitor.appendChild(address);
  monitor.appendChild(zip);
}

