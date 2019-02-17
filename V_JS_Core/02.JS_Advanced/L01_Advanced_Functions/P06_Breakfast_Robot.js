let manager = (function (){

    let storage = {
        protein : 0,
        carbohydrate : 0,
        fat : 0,
        flavour : 0
    };

    const recipes = {
        apple : {
            carbohydrate : 1,
            flavour : 2
        },
        coke : {
            carbohydrate : 10,
            flavour : 20
        },
        burger : {
            carbohydrate : 5,
            fat : 7,
            flavour : 3
        },
        omelet : {
            protein : 5,
            fat : 1,
            flavour : 1
        },
        cheverme : {
            protein : 10,
            carbohydrate : 10,
            fat : 10,
            flavour : 10
        }
    }

    return function (input) {

        let [command, item, quantity] = input.split(' ');

        const restock = (item, quantity) =>{
            storage[item] += +quantity;
            return 'Success';
        }

        const prepare = (item, quantity) =>{

            for(let ingrideint in recipes[item]){
                if(storage[ingrideint] < recipes[item][ingrideint] * quantity){
                    return `Error: not enough ${ingrideint} in stock`;
                }
            }

            for(let ingrideint in recipes[item]){
                storage[ingrideint] -= recipes[item][ingrideint] * quantity;
            }

            return 'Success';
        }

        const report = () =>{
            return Object.entries(storage)
            .map(item => `${item[0]}=${item[1]}`)
            .join(' ')
        }

        let action = {
            restock,
            prepare,
            report
        }

        return action[command](item, quantity);
    }

})();

console.log(manager('prepare cheverme 1'))
console.log(manager('restock protein 10'))
console.log(manager('prepare cheverme 1'))
console.log(manager('restock carbohydrate 10'))
console.log(manager('prepare cheverme 1'))
console.log(manager('restock fat 10'))
console.log(manager('prepare cheverme 1'))
console.log(manager('restock flavour 10'))
console.log(manager('prepare cheverme 1'))
console.log(manager('report'))
