function magicMatrices(matrix){
    let isRowEqual = true
    let firstRowSum = matrix[0].reduce((a, b) => a+b, 0)

    for (let i = 1; i < matrix.length; i++) {
        let currentRowSum = matrix[i].reduce((a, b) => a+b, 0)
        if(currentRowSum !== firstRowSum){
            isRowEqual = false
            break
        }
    }

    if(isRowEqual){

        for (let col = 0; col < matrix[0].length; col++) {
            let colSum = 0

            for (let row = 0; row < matrix.length; row++) {
                colSum += matrix[row][col]
            }
            if(colSum !== firstRowSum){
                isRowEqual = false
                break
            }
        }
    }

    return isRowEqual
}

console.log(magicMatrices([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
))