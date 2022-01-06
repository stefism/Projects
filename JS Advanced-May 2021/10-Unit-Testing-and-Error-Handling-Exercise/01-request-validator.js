function requestValidator(object) {
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validHttpVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let uriPattern = /^[a-zA-Z.0-9]+$/;
    let messagePattern = /^[a-zA-Z.\d\s]+$/;

    if(!validMethods.includes(object.method)){
        throw Error('Invalid request header: Invalid Method');
    }

    if(object.uri != '*'){
        if(object.uri == undefined || !uriPattern.test(object.uri)){
            throw Error('Invalid request header: Invalid URI');
        }
    }
    
    if(!validHttpVersions.includes(object.version)){
        throw Error('Invalid request header: Invalid Version');
    }

    if(object.message == undefined || object.message.length > 0){
        if(object.message == undefined || !messagePattern.test(object.message)){
            throw Error('Invalid request header: Invalid Message');
        }
    }

    return object;
}

console.log(requestValidator({
    method: 'GET',
    uri: 'ffff.ggg',
    version: 'HTTP/1.1',
    message: 'dddd dddd99.'
}));