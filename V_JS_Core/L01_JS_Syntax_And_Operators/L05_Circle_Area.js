function CalculateCircleArea(n){

    if (typeof(n) === 'number') {
        let result = (n**2) * Math.PI
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof (n)}.`)
    }
}

CalculateCircleArea(5)