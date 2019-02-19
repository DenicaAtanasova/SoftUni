const assert = require('chai').assert;
const lookupChar = require('../P03_Char_Lookup');

describe('lookupChar', function(){
    it('with a non-string first parameter, should return undefined', function(){
        assert.equal(lookupChar(13, 0), undefined, 'The function did not return the correct result!');
    });

    it('with a non-number second parameter, should return undefined', function(){
        assert.equal(lookupChar('pesho', 'gosho'), undefined, 'The function did not return the correct result!');
    });

    it('with a floating point number second parameter, should return undefined', function(){
        assert.equal(lookupChar('pesho', 3.12), undefined, 'The function did not return the correct result!');
    });

    it('with an incorrect index value, should return incorrecr index', function (){
        assert.equal(lookupChar('gosho', 13), 'Incorrect index', 'The function did not return the correct value!');
    });

    it('with a negative index value, should return incorrect index', function (){
        assert.equal(lookupChar('stamat', -1), 'Incorrect index', 'The function did not return the correct value!');
    });

    it('with an index value equal to string length, should return incorrect index', function (){
        assert.equal(lookupChar('pesho', 5), 'Incorrect index', 'The function did not return the correct value!');
    });

    it('with correct parameters, should return correct index', function (){
        assert.equal(lookupChar('pesho', 0), 'p', 'The function did not return the correct result!');
    });

    it('with correct parameters, should return correct index', function (){
        assert.equal(lookupChar('stamat', 3), 'm', 'The function did not return the correct result!');
    });
})