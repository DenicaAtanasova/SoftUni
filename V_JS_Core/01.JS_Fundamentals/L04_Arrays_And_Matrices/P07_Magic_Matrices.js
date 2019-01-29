function solve(matrix) {

    let transposedMatrix = transpose(matrix);

    let rowSum = matrix[0].reduce((a, b) => a + b, 0);
    let colSum = transposedMatrix[0].reduce((a, b) => a + b, 0);

    let isMagicMatrix = true;

    for(let row = 0; row < matrix.length; row++){
        if(rowSum !== matrix[row].reduce((a, b) => a + b, 0) ||
            colSum !== transposedMatrix[row].reduce((a, b) => a + b, 0)){
            isMagicMatrix = false;
            break;
        }
    }

    console.log(isMagicMatrix);

    function transpose(array){
        return array[0].map((col, i) => array.map(row => row[i]));
    }
}

solve([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);