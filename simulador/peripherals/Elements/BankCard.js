export class BankCard {
    constructor(jsonData) {
        this._cardNumber = jsonData.cardNumber;
        this._name = jsonData.name;
        this._thuDate = jsonData.thuDate;
        this._code = jsonData.code;
        this._bankName = jsonData.bankName;
        this._objectType = "card";
    }

    get cardNumber() {
        return this._cardNumber;
    }

    get name() {
        return this._name;
    }

    get thuDate() {
        return this._thuDate;
    }

    get code() {
        return this._code;
    }

    get bankName() {
        return this._bankName;
    }

    get objectType() {
        return this._objectType;
    }

    getInfo() {
        return {
            cardNumber: this._cardNumber,
            name: this._name,
            thuDate: this._thuDate,
            code: this._code,
            bankName: this._bankName,
            objectType: this._objectType
        };
    }
}