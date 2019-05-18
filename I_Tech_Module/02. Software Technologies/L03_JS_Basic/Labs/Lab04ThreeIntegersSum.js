function solve(arr) {
    let allElements = arr[0].split(' ');
    let firstNumber = Number(allElements[0]);
    let secondNumber = Number(allElements[1]);
    let thirdNumber = Number(allElements[2]);

    if(firstNumber + secondNumber === thirdNumber) {
        if (firstNumber > secondNumber) {
            [firstNumber, secondNumber] = [secondNumber, firstNumber];
        }
        console.log(`${firstNumber} + ${secondNumber} = ${thirdNumber}`);
    } else if (firstNumber + thirdNumber === secondNumber){
        if (firstNumber > thirdNumber) {
            [firstNumber, thirdNumber] = [thirdNumber, firstNumber];
        }
        console.log(`${firstNumber} + ${thirdNumber} = ${secondNumber}`);
    } else if (secondNumber + thirdNumber === firstNumber) {
        if (secondNumber > thirdNumber) {
            [secondNumber, thirdNumber] = [thirdNumber, secondNumber];
        }
        console.log(`${secondNumber} + ${thirdNumber} = ${firstNumber}`);
    } else {
        console.log('No');
    }
}

solve(['8 15 6'])