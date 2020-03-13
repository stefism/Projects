function everyEthElement(array) {
    let result = []
    let stepToPrint = Number(array.pop())
    for (let i = 0; i < array.length; i+=stepToPrint) {
        result.push(array[i])
    }

    return result.join('\n')
}

console.log(everyEthElement(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
))