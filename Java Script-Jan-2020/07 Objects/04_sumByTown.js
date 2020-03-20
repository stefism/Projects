function sumByTown(input) {
    let obj = {}

    for (let i = 0; i < input.length - 1; i += 2) {
        let town = input[i]
        let sumTown = +input[i + 1]

        if (typeof obj[input[i]] === "undefined") {
            obj[input[i]] = 0
        }

        obj[input[i]] += sumTown

    }
    let json = JSON.stringify(obj)

    return json
}

console.log(sumByTown(['Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4']
))