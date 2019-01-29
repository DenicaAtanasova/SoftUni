function solve(input) {

    for(let i = 1; i < input.length; i++){
        if(input[i] < input[i-1]){
            input.splice(i,1);
            i--;
        }
    }

    console.log(input.join('\r\n'));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);