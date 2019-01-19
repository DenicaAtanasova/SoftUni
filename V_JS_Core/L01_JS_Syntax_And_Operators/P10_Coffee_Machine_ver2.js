function Solve(orders) {

    let totalMoney = 0;

    for (let line of orders) {
        let order = line.split(', ');

        let coinsInserted = Number(order[0]);
        let drinkName = order[1];

        let sugarPrice = Number(order[order.length - 1] === '0' ? 0 : 10);
        let milkPrice = order[order.length - 2] === 'milk' ? 10 : 0;
        let drinkPrice = order[2] === 'decaf' ? 90 : 80;

        let moneyNeeded = (drinkPrice + milkPrice + sugarPrice) / 100;

        if (moneyNeeded <= coinsInserted){
            let change = (coinsInserted - moneyNeeded);
            console.log(`You ordered ${drinkName}. Price: ${(moneyNeeded).toFixed(2)}$ Change: ${(change).toFixed(2)}$`);
            totalMoney += moneyNeeded;
        } else {
            console.log(`Not enough money for ${drinkName}. Need ${(moneyNeeded - coinsInserted).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`)
}

Solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);