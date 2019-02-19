const assert = require('chai').assert
const isOddOrEven = require('../P02_Even_Or_Odd');

describe('isOddOrEven', function (){
    it('with a number parameter, should return undefined', function(){
        assert.equal(isOddOrEven(5), undefined, 'Function did not return the correct result!');
    });

    it('with an object parameter, should return undefined', function (){
        assert.equal(isOddOrEven({name: 'Pesho'}), undefined, 'Function did not return the correct result!');
    });

    it('with an even length string, should return correct result', function(){
        assert.equal(isOddOrEven('roar'), 'even', 'Function did not return the correct result!');
    });    

    it('with an odd length string, should return correct result', function(){
        assert.equal(isOddOrEven('pesho'), 'odd', 'Function did not return the correct result!');
    }); 

    it('with multiple consecutive checks, should return correct values', function(){
        assert.equal(isOddOrEven('cat'), 'odd', 'Function did not return the correct result!');
        assert.equal(isOddOrEven('alabala'), 'odd', 'Function did not return the correct result!');
        assert.equal(isOddOrEven('is it even'), 'even', 'Function did not return the correct result!');
    }); 
});