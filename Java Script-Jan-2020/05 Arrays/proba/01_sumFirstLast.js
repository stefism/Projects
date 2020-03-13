function sumFirstLast(array) {
    let firstElement = Number(array[0])
    let lastElement = Number(array[array.length - 1])
    let result = firstElement + lastElement

    console.log(result)
}

sumFirstLast(['20', '30', '40'])

