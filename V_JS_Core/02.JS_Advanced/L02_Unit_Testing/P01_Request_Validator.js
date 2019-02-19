function validateRequest(request){

    validateMethod();
    validateUri();
    validateVersion();
    validateMessage();

    function validateMethod(){
        let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
        if (!methods.includes(request.method) || !request.hasOwnProperty('method')){
            throw new Error(generateErrorMessage() + ' Method');
        }
    }

    function validateUri(){
        let uriPattern = /^(\*|[\w+\.]+)$/gi;
        if(!uriPattern.test(request.uri) || !request.hasOwnProperty('uri')){
            throw new Error(generateErrorMessage() + ' URI')
        }
    }

    function validateVersion(){
        let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
        if (!versions.includes(request.version) || !request.hasOwnProperty('version')){
            throw new Error(generateErrorMessage() + ' Version');
        }
    }

    function validateMessage(){
        let messagePattern = /^[^<>\\&'"]*$/g;
        if(!messagePattern.test(request.message) || !request.hasOwnProperty('message')){
            throw new Error(generateErrorMessage() + ' Message');
        }
    }

    function generateErrorMessage(){
        return 'Invalid request header: Invalid';
    }

    return request;
}

let request = {
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  };

  console.log(validateRequest(request));
