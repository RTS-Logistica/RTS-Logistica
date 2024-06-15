export class DataParse {
    constructor(jsonData, size)  
    {
        this._index = -1;
        this._size = size;
        this._jsonData = jsonData;
    } 

    hasNext(){
        return ++this._index < this._size;
    }

    get() {
        return {
            bankName : this._jsonData.bankName,
            UsersData: this._jsonData.usersData[this._index]
        }; 
    }
}