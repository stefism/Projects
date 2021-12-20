function addNumber(number) {
    return function(secondNumber) {
        return number + secondNumber;
    }
}

let add5 = addNumber(5);
console.log(add5(3));