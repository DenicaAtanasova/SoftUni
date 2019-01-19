function Solve(orders) {
    let Drinks = [
        {Name: 'coffee', Type: 'caffeine', Price: 80},
        {Name: 'coffee', Type: 'decaf', Price: 90},
        {Name: 'tea', Type: 'none', Price: 80}
    ];

    let totalMoney = 0;

    for (let line of orders) {
        let order = line.split(', ');

        let coinsInserted = Number(order[0]);
        let drinkName = order[1];
        let type = order[2] === 'milk' ? 'none' : order[2];

        let drink = Drinks.filter(element =>{
            return element.Name === drinkName && element.Type === type
        });
        let drinkPrice = Number(drink[0].Price);

        let sugarPrice = Number(order[order.length - 1] === '0' ? 0 : 10);
        let milkPrice = order[order.length - 2] === 'milk' ? 10 : 0;

        let moneyNeeded = (drinkPrice + milkPrice + sugarPrice) / 100;

        if (moneyNeeded <= coinsInserted){
            let change = (coinsInserted - moneyNeeded);
            console.log(`You ordered ${drink[0].Name}. Price: ${moneyNeeded.toFixed(2)}$ Change: ${(change).toFixed(2)}$`);
            totalMoney += moneyNeeded;
        } else {
            console.log(`Not enough money for ${drink[0].Name}. Need ${(moneyNeeded - coinsInserted).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`)
}

Solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
        '1.00, coffee, decaf, 0']
);