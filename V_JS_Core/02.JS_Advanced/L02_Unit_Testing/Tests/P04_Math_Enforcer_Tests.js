const assert = require('chai').assert;
const mathEnforcer = require('../P04_Math_Enforcer');

describe('mathEnforcer', function(){
    describe('addFive', function(){
        it('with a non-number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.addFive('s'), undefined, 'Function did not return the correct result!');
        });

        it('with a negative number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.addFive(-2), 3, 'Function did not return the correct result!');
        });

        it('with a floating point number parameter, should return correct result', function(){
            assert.closeTo(mathEnforcer.addFive(3.55), 8.56, 0.01, 'Function did not return the correct result!');
        });

        it('with a correct number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.addFive(4), 9, 'Function did not return the correct result!');
        });
    });

    describe('subtractTen', function(){
        it('with a non-number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.subtractTen('s'), undefined, 'Function did not return the correct result!');
        });

        it('with a negative number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.subtractTen(-2), -12, 'Function did not return the correct result!');
        });

        it('with a floating point number parameter, should return correct result', function(){
            assert.closeTo(mathEnforcer.subtractTen(13.55), 3.56, 0.01, 'Function did not return the correct result!');
        });

        it('with a correct number parameter less than 10, should return correct result', function(){
            assert.equal(mathEnforcer.subtractTen(4), -6, 'Function did not return the correct result!');
        });

        it('with a correct number parameter bigger than 10, should return correct result', function(){
            assert.equal(mathEnforcer.subtractTen(14), 4, 'Function did not return the correct result!');
        });
    });

    describe('sum', function(){
        it('with a non-number first parameter, should return correct result', function(){
            assert.equal(mathEnforcer.sum('s', 3), undefined, 'Function did not return the correct result!');
        });

        it('with a non-number second parameter, should return correct result', function(){
            assert.equal(mathEnforcer.sum(3, 's'), undefined, 'Function did not return the correct result!');
        });

        it('with both non-number parameters, should return correct result', function(){
            assert.equal(mathEnforcer.sum('d', 's'), undefined, 'Function did not return the correct result!');
        });

        it('with a negative number parameter, should return correct result', function(){
            assert.equal(mathEnforcer.sum(-2, 9), 7, 'Function did not return the correct result!');
        });

        it('with a floating point number first parameter, should return correct result', function(){
            assert.closeTo(mathEnforcer.sum(7, 13.55), 20.56, 0.01, 'Function did not return the correct result!');
        });

        it('with a floating point number second parameter, should return correct result', function(){
            assert.closeTo(mathEnforcer.sum(13.55, 7), 20.56, 0.01, 'Function did not return the correct result!');
        });

        it('with correct number parameters, should return correct result', function(){
            assert.equal(mathEnforcer.sum(14, 6), 20, 'Function did not return the correct result!');
        });
    });
});