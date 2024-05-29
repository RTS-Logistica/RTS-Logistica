export function showInMonitor(container, number) {
  const monitor = container.querySelector(".monitorText");
  const cardNumber = document.createElement("p");
  cardNumber.textContent = `${number}`;
  monitor.appendChild(cardNumber);
}

export function drawCard(container, cardData) {
  return container.innerHTML = ` 
    <div class="credit-card">
      <div class="bank-name">${cardData.bankName()}</div>
      <div class="card-number">${cardData.cardNumber()}</div>
      <div class="card-holder">
        <span class="label">Nombre del Titular:</span>
        <span class="name">${cardData.name()} ${cardData.surname()}</span>
      </div>
    </div>
    `;
}

export function drawBrochure(container, brochureData) {
  return container.innerHTML = ` 
  <div class="brochure">
  <div class="personal-info">
      <div class="info-item">
          <span class="label">Nombre y Apellido:</span>
          <span class="value">${brochureData.name()} ${brochureData.surname()}</span>
      </div>
      <div class="info-item">
          <span class="label">Dirección:</span>
          <span class="value">${brochureData.address()}</span>
      </div>
      <div class="info-item">
          <span class="label">Ciudad:</span>
          <span class="value">${brochureData.city()}</span>
      </div>
      <div class="info-item">
          <span class="label">Código Postal:</span>
          <span class="value">${brochureData.zipCode()}</span>
      </div>
  </div>
  ${this.drawCard(brochureData.cardBank())}
    `;
}

export function drawEnvelope(container, envelopeData) {
  return container.innerHTML = ` 
  <div class="envelope">
      <div class="envelope-header">
          <img src="https://via.placeholder.com/100x50" alt="Logo del Banco" class="bank-logo">
          <div class="bank-slogan">Tu confianza, nuestro compromiso</div>
      </div>
      <div class="envelope-footer">
          <div class="address">Calle Falsa 123</div>
          <div class="postal-code">12345 Ciudad Ejemplo</div>
      </div>
  </div>`;
}