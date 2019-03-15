const HolidayPackage = require('./holidayPackage');
const assert = require('chai').assert;

describe('HolidayPackage', function(){

    let hp;
    beforeEach(() => {
        hp = new HolidayPackage('Barcelona', 'Summer');
    });

    describe('showVacationers', function(){
        it('with no vacationers', function(){
            assert.equal(hp.showVacationers(), 'No vacationers are added yet');
        });
    });

    describe('addVacationer', function(){
        it('with incorrect parameter', function(){
            assert.throw(()=> hp.addVacationer(' '), 'Vacationer name must be a non-empty string');
            assert.throw(()=> hp.addVacationer(1), 'Vacationer name must be a non-empty string');
            assert.throw(()=> hp.addVacationer('name'), 'Name must consist of first name and last name');
        });
    });
  
    describe('insuranceIncluded', function(){
        it('insurance default value shoukd be false', function(){          
            assert.equal(hp.insuranceIncluded, false);
        });

        it('change insurance to not a boolean type', function(){          
            assert.throw(()=> hp.insuranceIncluded = 1, 'Insurance status must be a boolean');
        });
    });

    describe('generateHolidayPackage', function(){
        it('with no vacationers', function(){
            assert.throw(()=> hp.generateHolidayPackage(), 'There must be at least 1 vacationer added');
        });

        it('should return correct information', function(){
            hp.addVacationer('Denica Dimitrova');
            hp.addVacationer('Petko Nedelchev');

            console.log(hp.generateHolidayPackage());
            let expectedMessage = 'Holiday Package Generated\n'+
                                'Destination: Barcelona\n'+
                                'Vacationers:\n'+
                                'Denica Dimitrova\n'+
                                'Petko Nedelchev\n'+
                                'Price: 1000';

            assert.equal(hp.generateHolidayPackage(), expectedMessage);
        });
    });
})