function magicMatrices(matrix){
    let rows = matrix.length;
    let cols = matrix[0].length;

    let sumsRows = [];
    let sumCols = [];

    for (let row = 0; row < rows; row++) {
        let currSum = matrix[row].reduce((acc, curr) => acc + curr, 0);
        sumsRows.push(currSum);
    }

    for (let col = 0; col < cols; col++) {
        let currSum = 0;
        
        for (let row = 0; row < rows; row++) {
            currSum += matrix[row][col];
        }
        
        sumCols.push(currSum);
    }

    let allSums = sumsRows.concat(sumCols);

    return allSums.every((element, index, array) => element == array[0]);
}

console.log(magicMatrices([
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
]));