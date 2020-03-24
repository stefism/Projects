function uniqueSequences(input) {
    let nestedArrays = input.map(JSON.parse)

    let uniqueArrays = []

    for(let array of nestedArrays){
        let sum = array.reduce((a, b) => a + b, 0)
        let containsSum = uniqueArrays
            .some((x) => x.reduce((a, b) => a + b, 0) === sum)

        if(!containsSum){
            uniqueArrays.push(array.sort((a, b) => b - a))
        }
    }

    let output = uniqueArrays
        .sort((a, b) => a.length - b.length)
        .map((x) => `[${x.join(', ')}]`)
        .join('\n')

    return output
}

console.log(uniqueSequences(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
))