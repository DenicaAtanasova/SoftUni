let extensible = (function (){
    let id = 0;
    return class obj{
        constructor(){
            if(new.target)
            this.id = id++;
        }

        extend(template){
            Object.keys(template).forEach(x => {
                if(typeof template[x] === 'function'){
                    Object.getPrototypeOf(this)[x] = template[x];
                } else{
                    this[x] = template[x];
                }
            });
        }
    }
})();

let a = new extensible();
let b = new extensible();
let c = new extensible();

let template = {name : 'az', func : function () {console.log('Test');
}};

a.extend(template);