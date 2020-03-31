function addNumber(number) {
    return function (n) {
        return n+number
    }
}

let add5 = addNumber(5)
console.log(add5(2))