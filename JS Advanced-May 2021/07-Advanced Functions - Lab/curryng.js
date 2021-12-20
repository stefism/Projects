let greetCurry = function(name) {
    return function(message) {
        console.log(`Hey ${name}, ${message}`);
    }
}

let greetPesho = greetCurry('Pesho');
greetPesho('Hi');

greetCurry('Pesho')('Hi.'); //Извикваме greetCurry и резултата от тази функция го викаме (върнатата функция), отново го извикваме с function invocation. (вторите скоби).
// По презумция Curry функциите са само с по един параметър или онарни функции.