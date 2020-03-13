function equal(matrix) {
    let result = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if(col+1 < matrix[row].length){
                if(matrix[row][col] === matrix[row][col+1]){
                    result++
                }
            }

            if(row+1 < matrix.length){
                if(matrix[row][col] === matrix[row+1][col]){
                    result++
                }
            }
        }
    }

    return result
}

console.log(equal([['2', '2', '5', '7', '4'],
                         ['4', '0', '5', '3', '4'],
                         ['2', '5', '5', '4', '2']]
))