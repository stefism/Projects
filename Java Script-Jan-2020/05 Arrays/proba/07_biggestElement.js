function biggestElement(matrix) {
    let firstBiggest = Math.max.apply(Math, matrix[0])

    for (let row = 1; row < matrix.length; row++) {
        let currentBiggest = Math.max.apply(Math, matrix[row])

        if(currentBiggest > firstBiggest){
            firstBiggest = currentBiggest
        }
    }

    console.log(firstBiggest)
}

biggestElement(
    [[3, 5, 7, 12],
        [-1, 4, 33, 2],
        [8, 3, 0, 4]]

)