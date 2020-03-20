function increasingSubsequence(array) {
    let result = [array[0]]
    let biggest = array[0]

    for (let i = 1; i < array.length; i++) {
        if(biggest <= array[i]){
            biggest = array[i]
            result.push(biggest)
        }
    }

    return result.join('\n')
}

console.log(increasingSubsequence([20,
    3,
    2,
    15,
    6,
    1]
))