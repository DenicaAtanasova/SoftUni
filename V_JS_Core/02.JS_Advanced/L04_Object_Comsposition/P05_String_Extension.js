(function(){
    String.prototype.ensureStart = function(str) {
        if(!this.toString().startsWith(str)){
            return str + this;
        }

        return '' + this;
    };

    String.prototype.ensureEnd = function(str) {
        if(!this.toString().endsWith(str)){
            return this + str;
        }

        return '' + this;
    };

    String.prototype.isEmpty = function() {
        if(this.length === 0){
            return true;
        }

        return false;
    };

    String.prototype.truncate = function(n) {   
        let ellipsis = '...';    

        if (this.length > n) {
            if(n < 4){
                return '.'.repeat(n);
            }
            if(this.includes(' ')){
                let lastSpaceIndex = this.toString().substr(0, n - 2).lastIndexOf(' ');

                return this.substr(0, lastSpaceIndex) + ellipsis;
            } else{
                return this.substr(0, n - 3) + ellipsis;
            }
        }

        return '' + this;
    };

    String.format = function(str, ...params) {
        for (let i = 0; i < params.length; i++) {
            let placeHolder = `{${i}}`;
            if (str.includes(placeHolder)) {
                str = str.replace(placeHolder, params[i]);
            }
        }

        return '' + str;
    };
})();

let str = 'my string'
str = str.ensureStart('my');
str = str.ensureStart('hello ');
console.log(str = str.ensureEnd('string'));
console.log(str = str.ensureEnd(' :)'));
console.log(str = str.isEmpty());
console.log(str = str.truncate(16)); 
console.log(str = str.truncate(14));
console.log(str = str.truncate(8));
console.log(str = str.truncate(4));
console.log(str = str.truncate(2));
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');
