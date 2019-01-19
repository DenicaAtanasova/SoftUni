function Solve(number) {

    let currentNum;
    let previousNum;
    let sum = 0;

    let areNumsSame = true;

    while (number > 0) {
        currentNum = number % 10;
        number = (number / 10)|0;
        sum += currentNum;

        if (previousNum !== undefined){
            if (previousNum !== currentNum) {
                areNumsSame = false
            }
        }

        previousNum = currentNum;
    }

    console.log(areNumsSame);
    console.log(sum);
}

Solve(1234);