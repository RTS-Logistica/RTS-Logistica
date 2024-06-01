export class Brochure {
    
    constructor(jsonData) 
    {
        this._name = jsonData.userName;
        this._surname = jsonData.userSurame;
        this._city = jsonData.city;
        this._zip = jsonData.zip;
        this._address = jsonData.address;
        this.cardBank = null;
        this.objectType = "brochure"
    } 

    addItem(item){
        this.cardBank = item;
    }

    getFullInfo(){
        return {
            name: this._name,
            surname: this._surname,
            city: this._city,
            zip: this._zip,
            address: this._address,
            cardBank: this.cardBank 
        };
    }

    get name() {
        return this._name;
    }

    get surname() {
        return this._surname;
    }

    get city() {
        return this._city;
    }

    get zip() {
        return this._zip;
    }

    get address() {
        return this._address;
    }

    get cardBank() {
        return this.cardBank;
    }

    get objectType() {
        return this.objectType;
    }
}