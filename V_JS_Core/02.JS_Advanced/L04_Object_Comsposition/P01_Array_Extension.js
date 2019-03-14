(function solve(){
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        let result = [];
        for (let index = n; index < this.length; index++) {
            result.push(this[index]);
        }
        return result;
    }

    Array.prototype.take = function (n) {
        let result = [];
        for (let index = 0; index < n; index++) {
            result.push(this[index]);
        }
        return result;
    }

    Array.prototype.sum = function () {
        let sum = 0;

        this.forEach(element => {
            sum += element;
        });

        return sum;
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})()

let myArr = [1, 2, 3];

console.log(myArr.average());