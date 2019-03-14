function solve(car) {
    let engines = [{ power: 90, volume: 1800 }, { power: 120, volume: 2400 }, { power: 200, volume: 3500 }];
    let wheel = car.wheelsize % 2 === 0 ? car.wheelsize - 1 : car.wheelsize;

    return {
        model: car.model,
        engine: engines.filter(e => e.power >= car.power)[0],
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: [wheel, wheel, wheel, wheel]
    }
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));
