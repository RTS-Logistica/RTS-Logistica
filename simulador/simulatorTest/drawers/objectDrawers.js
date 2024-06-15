export function drawCard(container, data) {
    container.innerHTML = getCardHTML(data) + container.innerHTML;
}

function getCardHTML(data) {
    return ` 
    <div class="card-class-container">
        <div class="bank-name">${data.bankName}</div>
        <div class="card-number">${data.UsersData.cardNumber}</div>
        <div class="card-holder">
            <span class="name">${data.UsersData.userName} ${data.UsersData.userSurname}</span>
        </div>
    </div>
    `;
}

// "{"CardNumber":381713195306,"Name":null,"Surname":null,"Addres":null,"City":"Florencio Varela","State":"Santa Fe","ZipCode":2317}"
export function drawBrochure(container, data) {
    let backup = container.innerHTML;
    container.innerHTML = ` 
    <div class="brochure-class-container">
        <div class="personal-info">
            <div class="info-item">
                <span class="value">${data.UsersData.userName} ${data.UsersData.userSurname}</span>
            </div>
            <div class="info-item">
                <span class="value">${data.UsersData.address}</span>
            </div>
            <div class="info-item">
                <span class="value">${data.UsersData.city}</span>
            </div>
            <div class="info-item">
                <span class="value">${data.UsersData.zipCode}</span>
        </div>
        ${getCardHTML(data)}
    </div>
    `;
    container.innerHTML += backup;
}
  
export function drawEnvelope(container, data) {
    let backup = container.innerHTML;
    container.innerHTML = `
    <div class="envelope-class-container">
        <div class="envelope-header">
            <img src="${data.logo}" alt="Logo del Banco" class="bank-logo">
            <div class="bank-slogan">${data.slogan}</div>
        </div>
        <div class="envelope-footer">
            <div class="postal-code">${data.UsersData.zipCode}</div>
            <div class="address">${data.UsersData.address}</div>
        </div>
    </div>`;
    container.innerHTML += backup;
}