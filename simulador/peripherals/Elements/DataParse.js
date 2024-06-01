export class DataParse {
    constructor(jsonData, index)  
    {
        this._bankName = jsonData.bankName;
        this._slogan = jsonData.slogan;
        this._logo = jsonData.logo;
        this._cardNumber = jsonData.usersData[index].cardNumber;
        this._name = jsonData.usersData[index].userName;
        this._surname = jsonData.usersData[index].userSurname;
        this._address = jsonData.usersData[index].address;
        this._city = jsonData.usersData[index].city;
        this._state = jsonData.usersData[index].state;
        this._zipCode = jsonData.usersData[index].zipCode;
    } 

    get bankName() {
        return this._bankName;
    }

    get slogan() {
        return this._slogan;
    }

    get logo() {
        return this._logo;
    }

    get cardNumber() {
        return this._cardNumber;
    }

    get name() {
        return this._name;
    }

    get surname() {
        return this._surname;
    }

    get address() {
        return this._address;
    }

    get city() {
        return this._city;
    }

    get state() {
        return this._state;
    }

    get zipCode() {
        return this._zipCode;
    }
}