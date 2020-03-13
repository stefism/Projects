function smallest2Numbers(array) {
    let result =[]

    for (let i = 0; i < 2; i++) {
        let firstSmallNumber = Math.min.apply(Math, array)
        let firstSmallIndex = array.indexOf(firstSmallNumber)
        result.push(firstSmallNumber)
        array.splice(firstSmallIndex, 1)
    }

    result.sort((a, b) => a - b)

    console.log(result.join(' '))
}

smallest2Numbers([3, 0, 10, 4, 7, 3])