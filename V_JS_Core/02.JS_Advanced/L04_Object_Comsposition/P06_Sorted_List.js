function result(){
    
    let collection = [];

    return {
        add : function(element){
            collection.push(element);
            collection.sort((a, b) => a - b);
            this.size ++
        },
        remove : function(index){
            if(index < 0 || index >= collection.length){
                throw new RangeError('Index out of range!')
            }
                collection.splice(index, 1);
                this.size --;
        },
        get : function(index){
            if(index < 0 || index >= collection.length){
                throw new RangeError('Index out of range!')
            }
                return collection[index];
        },
        size : 0
    }
}

var myList = result();
var failsafe = 'failsafe';

for (let i = 0; i < 10; i++) {
    myList.add(i);
}

console.log(myList.size);
