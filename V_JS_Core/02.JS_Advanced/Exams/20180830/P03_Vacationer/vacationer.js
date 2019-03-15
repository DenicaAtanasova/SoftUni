class Vacationer{
    constructor(fullName, creditCard = [1111, '', 111]){
        this.fullName = fullName;
        this.creditCard = creditCard;
        this.wishList = [];
        this.generateIDNumber();
    }

    get fullName(){
        return this._fullName;
    }

    set fullName(value){
        if (value.length < 3) {
            throw new Error('Name must include first name, middle name and last name');
        }

        let namePattern = /^[A-Z][a-z]+$/;
        if(!namePattern.test(value[0]) || !namePattern.test(value[1]) || !namePattern.test(value[2])){
            throw new Error('Invalid full name');
        }

        this._fullName = {
            firstName : value[0],
            middleName : value[1],
            lastName : value[2]
        };
    }

    get creditCard(){
        return this._creditCard;
    }

    set creditCard(value){
        this.addCreditCardInfo(value);
    }

    generateIDNumber() {
        let vowels = ['a', 'e', 'i', 'o', 'u'];

        this.idNumber = 231 * this.fullName.firstName.charCodeAt(0) + 139 * this.fullName.middleName.length;
        
        let lastNameLastChar = this.fullName.lastName[this.fullName.lastName.length - 1];
        if (vowels.includes(lastNameLastChar)) {
            this.idNumber += '8';
        } else {
            this.idNumber += '7';
        }
    }

    addCreditCardInfo(input){
        if(input.length < 3){
            throw new Error('Missing credit card information');
        }
        
        if(typeof input[0] !== 'number' || typeof input[2] !== 'number'){
            throw new Error('Invalid credit card details');
        }

        this._creditCard = {
            cardNumber : input[0],
            expirationDate : input[1],
            securityNumber : input[2]
        }
    }

    addDestinationToWishList(destination){
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        let result = `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\n` +
            `ID Number: ${this.idNumber}\n` +
            'Wishlist:\n';

        if (this.wishList.length === 0) {
            result += 'empty\n';
        } else {
            result += this.wishList.join(', ') + '\n';
        }
        result += 'Credit Card:\n' +
            `Card Number: ${this.creditCard.cardNumber}\n` +
            `Expiration Date: ${this.creditCard.expirationDate}\n` +
            `Security Number: ${this.creditCard.securityNumber}`;

        return result;
    }
}