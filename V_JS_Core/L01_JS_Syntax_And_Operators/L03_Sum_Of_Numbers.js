function SumNumbers(n, m){
    let firstNum = Number(n);
    let secondNum = Number(m);
    let result = 0;

    for (firstNum; firstNum <= secondNum; firstNum ++) {
        result += firstNum;
    }

    console.log(result)
}

SumNumbers('-8', '20')