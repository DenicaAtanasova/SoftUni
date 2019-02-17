let add = (function (){
    let sum = 0;

    function add(num){
        sum += num;
        return add;
    }

    add.toString = function(){
        return sum;
    };

    return add;
})()

add(1)(9)
console.log(add.toString());