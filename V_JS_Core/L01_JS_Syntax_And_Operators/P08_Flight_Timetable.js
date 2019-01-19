function Solve(flightInfo) {

    let direction = flightInfo[0];
    let town = flightInfo[1];
    let time = flightInfo[2];
    let flight = flightInfo[3];
    let gate = flightInfo[4];

    console.log(`${direction}: Destination - ${town}, Flight - ${flight}, Time - ${time}, Gate - ${gate}`)
}

Solve(['Arrivals', 'Paris', '02:22', 'VD17', '3']);