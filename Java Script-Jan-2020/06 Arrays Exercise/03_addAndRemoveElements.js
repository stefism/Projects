function addAndRemove(array) {
    let result = []
    let number = 1
    for (let i = 0; i < array.length; i++) {
        let command = array[i]

        switch (command) {
            case 'add':
                result.push(number)
                break;

            case 'remove':
                result.pop()
                break;
        }

        number++
    }

    return result.length > 0 ? result.join('\n') : 'Empty'
}

console.log(addAndRemove(['remove',
    'remove',
    'remove']

))