class sortedList{
    constructor(){
        this.collectoin = [];
        this.size = this.collectoin.length;
    }
    add(element){
        this.collectoin.push(element);
        this.size++;
        this.collectoin.sort((a,b) => {
            if(a < b){
                return -1;
            } else if(a > b){
                return 1;
            }
            return 0;
        });
    }

    remove(index){
        if(index < 0 || index >= this.size){
            throw new RangeError('Index out of range!')
        }
        this.collectoin.splice(index, 1);
        this.size--;
    }

    get(index){
        if(index < 0 || index >= this.size){
            throw new RangeError('Index out of range!')
        }
        return this.collectoin[index];
    }
}

let list = new sortedList();
console.log(list);

list.add('aaa');
list.add('abb');
list.add('bbb');
list.add('aba');
console.log(list.size);