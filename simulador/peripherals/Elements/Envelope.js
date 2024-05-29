export class Envelope {
    
    constructor(jsonData) 
    {
        this._branchOfficeId = jsonData._branchOfficeId;
        this._name = jsonData.userName;
        this._surname = jsonData.userSurame;
        this._city = jsonData.city;
        this._zip = jsonData.zip;
        this._address = jsonData.address;
        this._barcode = jsonData.barcode;
        this.brochure = null;
        this.objectType = "envelope";
    } 

    addItem(item){
        this.tag = item;
    }

    getInfo(){
        return {
            branchOfficeId: this._branchOfficeId,
            name: this._name,
            surname: this._surname,
            city: this._city,
            zip: this._zip,
            barcode: this._barcode,
            address: this._address,
            brochure: this.brochure 
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

    get brochure() {
        return this.brochure;
    }

    get objectType() {
        return this.objectType;
    }

}