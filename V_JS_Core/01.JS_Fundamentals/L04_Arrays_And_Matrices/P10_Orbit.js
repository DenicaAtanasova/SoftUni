function solve(input) {
    let rows = input.shift();
    let cols = input.shift();
    let starRow = input.shift();
    let starCol = input.shift();

    let orbit = [];

    for(let row = 0; row < rows; row++){
        let rowArr = [];
        for(let col = 0; col < cols; col++){

            let num = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
            rowArr.push(num);
        }
        orbit.push(rowArr);
    }
    console.log(orbit.map(r => r.join(' ')).join('\n'));
}

solve([5, 5, 2, 2]);