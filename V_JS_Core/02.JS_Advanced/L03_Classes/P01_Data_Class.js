// class Request {
//     constructor(method, uri, version, message){
//         this.method = method;
//         this.uri = uri;
//         this.version = version;
//         this.message = message;
//         this.response = undefined;
//         this.fulfilled = false;
//     }
// }

function some(){
    console.log(this.name);
}

let a = (function(){
    return console.log(123456);
})();

let ba = a;
ba()
a
