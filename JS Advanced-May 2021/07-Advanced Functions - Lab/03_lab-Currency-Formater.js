function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function createFormatter(separator, symbol, symbolFirst, formatterFunction){
    // let solveFunction = function(value) {
    //     let result = formatterFunction(separator, symbol, symbolFirst, value);
    //     return result;
    // }

    // return solveFunction;

    return function(value) {
        return formatterFunction(separator, symbol, symbolFirst, value);
    }
} // Връщаме функция, която трябва да върне formatterFunction с подадените параметри! Демек два ретърна трябва да има! Ако напишем само formatterFunction на 10ти ред, няма да работи. Трябва да я ретърнем.

let dollarFormatter = createFormatter(',', '$', true, currencyFormatter);

console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709)); // $ 2,71