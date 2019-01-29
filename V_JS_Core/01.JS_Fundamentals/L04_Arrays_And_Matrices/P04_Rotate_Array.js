function solve(arr) {
    let rotationAmount = +arr.pop();

    if(rotationAmount % arr.length !== 0){
        for(let i = 0; i < rotationAmount % arr.length; i++){
            arr.unshift(arr.pop());
        }
    }

    console.log(arr.join(' '));
}

solve(['Banana', 'Orange', 'Coconut', 'Apple', '2']);