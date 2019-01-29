function solve(matrix) {

    let sumDiagonals = {main: 0, second: 0};
    let matrixLength = matrix.length;

    let resultMatrix = [];

    for (let i = 0; i < matrixLength; i++) {
        matrix[i] = matrix[i].split(' ');

        sumDiagonals.main += +matrix[i][i];
        sumDiagonals.second += +matrix[i][matrixLength-i-1];

        resultMatrix[i] = Array(matrix[i].length).fill(-1);
        resultMatrix[i][i] = matrix[i][i];
        resultMatrix[i][matrixLength-i-1] = matrix[i][matrixLength-i-1];
    }

    if(sumDiagonals.main === sumDiagonals.second){
        for(let item of resultMatrix){
            item.forEach(function(part, index) {
                if(this[index] === -1){
                    this[index] = sumDiagonals.main;
                }
            }, item);
        }

        console.log(resultMatrix.map(r => r.join(' ')).join('\n'));

    } else {
        console.log(matrix.map(r => r.join(' ')).join('\n'));
    }
}

solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);