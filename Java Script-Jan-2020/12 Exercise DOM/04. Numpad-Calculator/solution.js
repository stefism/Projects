function solve() {
    let keys = document.querySelectorAll('.keys')

    let arrKey = Array.from(keys).map(k => k.addEventListener('click', k => calculator(k)))
    let expressionOutput = document.getElementById('expressionOutput')
    let resultOutput = document.getElementById('resultOutput')
    let clearButton = document.getElementsByClassName('clear')[0]
        .addEventListener('click', clearOutputText)

    let number = ''
    let numbers = []

    function clearOutputText() {
        resultOutput.innerText = ''
        expressionOutput.innerText = ''
        number = ''
        numbers = []
    }

    function calculator(key) {
        let targetKey = key.target.value

        if(targetKey !== '+' && targetKey !== '-'
            && targetKey !== '*' && targetKey !== '/'
            && targetKey !== '='){
            number += targetKey
        } else {
            if(targetKey !== '='){
                numbers.push(+number)
                number = ''
                numbers.push(targetKey)
                expressionOutput.innerHTML += " "
            }
        }

        if(targetKey !== '='){

            expressionOutput.innerHTML += targetKey

        }

        if(targetKey === '+' || targetKey === '-'
            || targetKey === '*' || targetKey === '/'){
            expressionOutput.innerHTML += " "
        }

        if(targetKey === '='){

            if(number !== ''){
                numbers.push(+number)
            }

            if(numbers.length === 2){
                resultOutput.innerText = 'NaN'
            } else {
                let final = result()
                resultOutput.innerText = final
            }
        }
    }

    function result() {
        let result

            let a = numbers[0]
            let op = numbers[1]
            let b = numbers[2]

            result = applyOp(a, b, op)

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