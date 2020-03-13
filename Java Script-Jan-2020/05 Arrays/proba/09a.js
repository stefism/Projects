function equalNeighbors(matrix) {
    let result = 0

    for (let row = 0; row < matrix.length - 1; row++) {
        for (let col = 0; col < matrix[row].length - 1; col++) {
            if(matrix[row][col] === matrix[row][col+1]){
                result++
            }

            if(matrix[row][col] === matrix[row+1][col]){
                result++
            }
        }
    }

    for (let row = 0; row < matrix.length - 1; row++) {
        let value1 = matrix[row][matrix[row].length-1]
        let value2 = matrix[row+1][matrix[row].length-1]
        if(value1 === value2){
            result++
        }
    }

    for (let i = 0; i < matrix[matrix.length-1].length-1; i++) {
        let value1 = matrix[matrix.length-1][i]
        let value2 = matrix[matrix.length-1][i+1]
        if(value1 === value2){
            result++
        }
    }

    return result
}

console.log(equalNeighbors([['2', '2', '5', '7', '4'],
                                  ['4', '0', '5', '3', '4'],
                                  ['2', '5', '5', '4', '2']]
))