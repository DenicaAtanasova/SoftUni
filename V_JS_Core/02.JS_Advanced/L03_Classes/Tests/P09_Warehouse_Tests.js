const assert = require('chai').assert;
const Warehouse = require('../P09_Warehouse');

describe('Warehouse constructor tests', function(){
    it('with negative capacity parameter should throw an error', function(){
        let capacity = -1;
        assert.throws(() => new Warehouse(capacity), 'Invalid given warehouse space');
    });

    it('with NaN capacity parameter should throw an error', function(){
        let capacity = 'a';
        assert.throws(() => new Warehouse(capacity), 'Invalid given warehouse space');
    });

    it('with correct capacity parameter  should work correctly', function(){
        let capacity = 100;
        let warehouse = new Warehouse(capacity);
        assert.equal(warehouse.capacity, capacity, `Capacity must be ${capacity}, but was ${warehouse.capacity}`);
    });
});

describe('Warehouse functions tests', function(){   
    let type = 'Food';
    let product = 'tomatoe';
    let quantity = 10;

    let warehouse;
    let capacity = 100;
    beforeEach(function(){
        warehouse = new Warehouse(capacity);
    });

    describe('addProduct tests', function(){

        it('with addedQuantity bigger than capacity should throw an error', function(){
            assert.throws(() => warehouse.addProduct(type, product, 101), 'There is not enough space or the warehouse is already full');
        });

        it('with already added product, quantity must be increased', function () {
            let expectedQuantity = quantity * 2;

            warehouse.addProduct(type, product, quantity);
            let result = warehouse.addProduct(type, product, quantity);

            assert.equal(result[product], expectedQuantity, `Quantity must be ${expectedQuantity}, but was ${result[product]}`);
        });
    });

    describe('orderProduct tests', function(){

        it('', function(){
            warehouse.addProduct(type, 'potatoe', 20);
            warehouse.addProduct(type, 'cucumber', 30);
            warehouse.addProduct(type, 'onion', 10);

            let actualResult = warehouse.orderProducts(type);
            let expectedResult = {
                cucumber: 30,
                potatoe: 20,
                onion: 10
            };

            let actualProducts = JSON.stringify(actualResult);
            let expectedProducts = JSON.stringify(expectedResult);

            assert.equal(expectedProducts, actualProducts);
        });
    });

    describe('occupiedCapacity tests', function(){

        it('should return corecct result', function(){
            warehouse.addProduct(type, product, quantity); 

            let acturalCapacity = warehouse.occupiedCapacity();    
            assert.equal(acturalCapacity, 10, `Occupied capacity must be 10, but was ${acturalCapacity}`);
        });

        it('with zero products should return zero', function(){

            let acturalCapacity = warehouse.occupiedCapacity();    
            assert.equal(acturalCapacity, 0, `Occupied capacity must be 0, but was ${acturalCapacity}`)
        });
    });

    describe('revision tests', function(){
        
        it('with occupied capacity equl to zero should return a message', function (){
            let expectedMessage = 'The warehouse is empty';
            let actualMessage = warehouse.revision();
            assert.equal(actualMessage, expectedMessage, `Message must be ${expectedMessage} but is ${actualMessage}`);
        });

        it('with occupied capacity bigger than zero should return a message', function (){
            
            warehouse.addProduct(type, product, quantity);

            let expectedMessage = 'Product type - [Food]\n' +
                                  '- tomatoe 10\n' +
                                  'Product type - [Drink]';
            let actualMessage = warehouse.revision();
            assert.equal(actualMessage, expectedMessage, `Message must be ${expectedMessage} but is ${actualMessage}`);
        });
    });

    describe('scrapeAProduct tests', function(){
        it('with no products should return message', function(){
            
            let expectedMessage = `${product} do not exists`;
            assert.throws(() => warehouse.scrapeAProduct(product, quantity), expectedMessage);
        });

        it('with existing product should reduce his quantity', function(){
            warehouse.addProduct(type, product, quantity);
            warehouse.addProduct(type, product, quantity);

            warehouse.scrapeAProduct(product, quantity);

            actualQuantity = warehouse.availableProducts[type][product];
            expectedQuantity = 10;

            assert.equal(actualQuantity, expectedQuantity, `Expected quantity to be ${expectedQuantity} but is ${actualQuantity}`);
        });

        it('with existing product should reduce his quantity to zero', function(){
            warehouse.addProduct(type, product, quantity);

            warehouse.scrapeAProduct(product, 20);

            actualQuantity = warehouse.availableProducts[type][product];
            expectedQuantity = 0;

            assert.equal(actualQuantity, expectedQuantity, `Expected quantity to be ${expectedQuantity} but is ${actualQuantity}`);
        });
    });
})