// Function declarations.

function printMessage(text){
    console.log(text);
} // Function declaration.

printMessage("Message.");

let printMessage2 = function(text){
    console.log(text)
} //Function expression.

let sum = (a, b) => {
    console.log(a + b);
} //Arrow function.

sum(2, 10);

function calculate(a, b) {
    return a + b;
}

let result = calculate(2, 20);
console.log(result);