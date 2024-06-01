export function drawCard(container, data) {
    return container.innerHTML = ` 
    <div class="credit-card-class-container">
        <div class="bank-name">${data.bankName()}</div>
        <div class="card-number">${data.cardNumber()}</div>
        <div class="card-holder">
            <span class="label">Nombre del Titular:</span>
            <span class="name">${data.name()} ${data.surname()}</span>
        </div>
    </div>
    `;
}
  
export function drawBrochure(container, data) {
    return container.innerHTML = ` 
    <div class="brochure-class-container">
        <div class="personal-info">
            <div class="info-item">
                <span class="label">Nombre y Apellido:</span>
                <span class="value">${data.name()} ${data.surname()}</span>
            </div>
            <div class="info-item">
                <span class="label">Dirección:</span>
                <span class="value">${data.address()}</span>
            </div>
            <div class="info-item">
                <span class="label">Ciudad:</span>
                <span class="value">${data.city()}</span>
            </div>
            <div class="info-item">
                <span class="label">Código Postal:</span>
                <span class="value">${data.zipCode()}</span>
        </div>
        ${this.drawCard(data.cardBank())}
    </div>
    `;
}
  
export function drawEnvelope(container, data) {
    return container.innerHTML = ` 
    <div class="envelope-class-container">
        <div class="envelope-header">
            <img src="${data.logo()}" alt="Logo del Banco" class="bank-logo">
            <div class="bank-slogan">${data.slogan()}</div>
        </div>
        <div class="envelope-footer">
            <div class="address">${data.address()}</div>
            <div class="postal-code">${data.zipCode()}</div>
        </div>
    </div>`;
}