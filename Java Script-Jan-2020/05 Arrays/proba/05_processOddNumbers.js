function oddNumbers(array) {
    let result =[]
    for (let i = 0; i < array.length; i++) {
        if(i % 2 !== 0){
            result.push(array[i] *= 2)
        }
    }

    result.reverse()

    console.log(result.join(' '))
}

oddNumbers([3, 0, 10, 4, 7, 3])