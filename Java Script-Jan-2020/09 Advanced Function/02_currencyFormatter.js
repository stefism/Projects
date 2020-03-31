function currencyFormatter(value) {
    let separator = ','
    let symbol = '$'
    let symbolFirst = true

    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function result(formatter){

    return formatter
}

let dollarFormatter = result(currencyFormatter)
console.log(dollarFormatter(5345))
