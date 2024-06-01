export class DataParse {
    constructor(jsonData, size)  
    {
        this._index = -1;
        this._size = size;
        this._jsonData = jsonData;
    } 

    next(){
        return ++this._index < this._size;
    }

    bankName() {
        return this._jsonData.bankName;
    }

    slogan() {
        return this._jsonData.slogan;
    }

    logo() {
        return this._jsonData.logo;
    }

    cardNumber() {
        return this._jsonData.usersData[this._index].cardNumber;
    }

    name() {
        return this._jsonData.usersData[this._index].userName;
    }

    surname() {
        return this._jsonData.usersData[this._index].userSurname;
    }

    address() {
        return this._jsonData.usersData[this._index].address;
    }

    city() {
        return this._jsonData.usersData[this._index].city;
    }

    state() {
        return this._jsonData.usersData[this._index].state;
    }

    zipCode() {
        return this._jsonData.usersData[this._index].zipCode;
    }
}