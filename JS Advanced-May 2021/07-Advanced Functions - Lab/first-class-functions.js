//First-Class Functions - Могат да се присвояват на променливи, могат да се подават като параметри на други функции и да се връщат като резултат от функции.
function hello(name) {
    return `Hello, ${name}`;
}

function fancyHello(name) {
    return `Fancy Hello Mr. ${name}`;
}

function greet(personName, helloFunction) {
    return helloFunction(personName);
}

// helloFunction може да бъде в случая или hello или fancyHello.

console.log(greet('Pesho', hello));
console.log(greet('Gosho', fancyHello));

// Функцията също така може и да връща функция.

function greetReturn(name) {
    return function messageReturn(message) {
        console.log(`Hello there ${name}. ${message}`);
    }
}

let greetPesho = greetReturn('Pesho'); /* Така функцията messageReturn(message) се записва в променлвата greetPesho. В момента в greetPesho ще бъде записано за console.log съобщението Hello there Pesho. Или все едно в променливата greetPesho връщаме ето това:
function messageReturn(message) {
    console.log(`Hello there Pesho, ${message}`);
} 
*/

greetPesho('How are you?'); // Hello there Pesho. How are you?
greetPesho('Do you want cup of tea?'); // Hello there Pesho. Do you want cup of tea?