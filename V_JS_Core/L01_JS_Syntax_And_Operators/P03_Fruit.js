function Solve(fruit, weightInGrams, price){
    let weight = weightInGrams/1000;
    let money = weight * price;

    console.log(`I need ${money.toFixed(2)} leva to buy ${weight.toFixed(2)} kilograms ${fruit}.`)
}

Solve('applee', 1563, 2.35);