function solve(arr) {

    arr.sort(function(a, b){
        if(a.length === b.length){
            return a > b;
        } else{
            return a.length - b.length;
        }
    });

    console.log(arr.join('\r\n'));
}

solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);