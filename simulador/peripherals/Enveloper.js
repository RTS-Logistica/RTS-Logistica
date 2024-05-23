export class Enveloper {

    cardBank;
    
    constructor(branchOfficeId, name, surname, city, zip, barcode) 
    {
        this._branchOfficeId = branchOfficeId;
        this._name = name;
        this._surname = surname;
        this._city = city;
        this._zip = zip;
        this._barcode = barcode;
        this.cardBank = null;
    } 

    addCard(card){
        this.cardBank = card;
    }

    getFullEnvelope(){
        return {
            branchOfficeId: this._branchOfficeId,
            name: this._name,
            surname: this._surname,
            city: this._city,
            zip: this._zip,
            barcode: this._barcode,
            cardBank: this.cardBank 
        };
    }

    getEnvelope(){
        return {
            branchOfficeId: this._branchOfficeId,
            name: this._name,
            surname: this._surname,
            city: this._city,
            zip: this._zip,
            barcode: this._barcode,
        };
    }

}