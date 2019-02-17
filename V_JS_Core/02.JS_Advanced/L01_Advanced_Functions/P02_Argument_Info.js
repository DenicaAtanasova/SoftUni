function myFunc(){
    let typeCounter = [];

    for (let i = 0; i < arguments.length; i++) {
        var obj = arguments[i];
        var type = typeof obj;
        console.log(type + ': ' + obj); 
        
        if(!typeCounter.some(x => x[0] === type)){
            typeCounter.push([type, 1]);
        } else{
            let searchedType = typeCounter.find(x => x[0] === type)
            typeCounter[typeCounter.indexOf(searchedType)][1] ++;
        }      
    }
    
    typeCounter.sort((a, b) => b[1] - a[1])
               .forEach(x => console.log(`${x[0]} = ${x[1]}`));
}

myFunc('cat', 'dog', 42, 3, 33, function () { console.log('Hello world!'); });