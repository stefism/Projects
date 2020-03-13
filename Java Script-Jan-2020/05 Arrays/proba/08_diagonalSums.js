function diagonalSums(matrix) {
    let leftSum = 0;
    let rightSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        leftSum += matrix[row][row]
        rightSum += matrix[row][matrix.length-1-row]
    }

    console.log(leftSum + ' ' + rightSum)
}

diagonalSums([[20, 40],
    [10, 60]]

)