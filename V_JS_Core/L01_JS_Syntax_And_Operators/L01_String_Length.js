function CalculateStringLength(firstString, secondString, thirdString){
    let firstStringLength = firstString.length;
    let secondStringLength = secondString.length;
    let thirdStringLength = thirdString.length;

    let lengthSum = firstStringLength + secondStringLength + thirdStringLength;
    let lengthAvarageSum = Math.floor(lengthSum/3);

    console.log(lengthSum);
    console.log(lengthAvarageSum);
}

CalculateStringLength ("az", "ti", "te");