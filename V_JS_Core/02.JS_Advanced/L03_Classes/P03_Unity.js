class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }
    unite (rat) {
        if(rat instanceof Rat){
            this.unitedRats.push(rat);
        }
    }
    getRats(){
        return this.unitedRats;
    }

    toString(){
        let output = '';
            if(this.unitedRats.length > 0){
                output = this.name + '\n' +
                this.unitedRats.map(x => `##${x.name}`).join('\n');
            }else{
                output = this.name;
            }
        return output;
    }
}

let test = new Rat('Pesho');
console.log(test.toString());
console.log(test.getRats());

test.unite(new Rat('Gosho'));
test.unite(new Rat('Sasho'));
test.unite('bug');

console.log(test.getRats());
console.log(test.toString());