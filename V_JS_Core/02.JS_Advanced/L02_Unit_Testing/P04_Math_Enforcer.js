let mathEnforecer = {
    addFive: function(num){
        if(isNaN(num)){
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function(num){
        if(isNaN(num)){
            return undefined;
        }
        return num -10;
    },
    sum: function(num1, num2){
        if(isNaN(num1) || isNaN(num2)){
            return undefined;
        }
        return num1 + num2;
    }
};

module.exports = mathEnforecer;