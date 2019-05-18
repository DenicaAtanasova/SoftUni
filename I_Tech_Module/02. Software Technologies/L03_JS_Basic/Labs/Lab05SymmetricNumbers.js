function solve(arr){
    let n = +arr[0];
    let symmetricArr=[];

    for(let i = 1; i <= n; i++){
        if(isSymmetric(i)){
            symmetricArr.push(i);
        }
    }
    console.log(symmetricArr.join(' '));

    function isSymmetric(num) {
        let reversedArr = num.toString().split('').reverse().join('');
        return reversedArr === num.toString();
    }
}
solve(['750']);