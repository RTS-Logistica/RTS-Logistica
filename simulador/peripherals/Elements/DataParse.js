export class DataParse {
    constructor(jsonData, size)  
    {
        this._index = 0;
        this._size = size;
        this._jsonData = jsonData;
    } 

    next(){
        return ++this._index < this._size;
    }

    get bankName() {
        return this._jsonData.bankName;
    }

    get slogan() {
        return this._jsonData.slogan;
    }

    get logo() {
        return this._jsonData.logo;
    }

    get cardNumber() {
        return this._jsonData.usersData[index].cardNumber;
    }

    get name() {
        return this._jsonData.usersData[index].userName;
    }

    get surname() {
        return this._jsonData.usersData[index].userSurname;
    }

    get address() {
        return this._jsonData.usersData[index].address;
    }

    get city() {
        return this._jsonData.usersData[index].city;
    }

    get state() {
        return this._jsonData.usersData[index].state;
    }

    get zipCode() {
        return this._jsonData.usersData[index].zipCode;
    }
}