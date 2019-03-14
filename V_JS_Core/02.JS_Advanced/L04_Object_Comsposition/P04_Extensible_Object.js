function solve(){
    return {
        extend : function(obj){
            Object.keys(obj).forEach(x => {
                if(typeof obj[x] === 'function'){
                    Object.getPrototypeOf(this)[x] = obj[x];
                } else{
                    this[x] = obj[x];
                }
            });
        }
    }
}