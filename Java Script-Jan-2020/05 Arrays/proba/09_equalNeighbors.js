function intersect(a, b) {
    return a.filter((element, index) => b[index] === element).length
}

function solve(matrix) {
    let result = 0;
    for (let i = 0; i < matrix.length - 1; i++) {
        result += intersect(matrix[i], matrix[i + 1])
    }
    return result
}

console.log(solve([['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
))


