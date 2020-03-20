function rotateArray(array) {
    let rotates = Number(array.pop())

    for (let i = 0; i < rotates; i++) {
        let element = array.pop()
        array.unshift(element)
    }

    return array.join(' ')
}

console.log(rotateArray(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
))