function solve() {
    let keys = document.querySelectorAll('.keys')
    //debugger
    let arrKey = Array.from(keys).map(k => k.addEventListener('click', k => calculator(k)))
    let expressionOutput = document.getElementById('expressionOutput')
    let resultOutput = document.getElementById('resultOutput')
    //debugger
    let number = ''
    let numbers = []

    function calculator(key) {
        let targetKey = key.target.value

        if(targetKey === '='){
            numbers.push(+number)
            let final = result()

            //debugger
        }
        //debugger
        if(targetKey !== '+' && targetKey !== '-'
        && targetKey !== '*' && targetKey !== '/'){
            number += targetKey
        } else {
            numbers.push(+number)
            number = ''
            numbers.push(targetKey)
            //debugger
        }
        expressionOutput.innerText += targetKey
        //debugger
    }

    function result() {
        let result

            let a = numbers[0]
            let op = numbers[1]
            let b = numbers[2]

            result = applyOp(a, b, op)
        //debugger
        return result
    }
    
    function applyOp(a, b, op) {
        switch (op) {
            case '+': return a+b
            case '-': return a-b
            case '*': return a*b
            case '/': return a/b
        }
    }
}