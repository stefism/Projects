function kNumbers(arrayLength, sequence) {
    let result =[1]
    let nextValue;
    for (let i = 0; i < arrayLength - 1; i++) {
        if(i-sequence < 0){
            nextValue = result.slice(0, i+1)
        } else {
            nextValue = result.slice(i-(sequence-1), i+1)
        }

        let sum = nextValue.reduce((a, b) => a+b)
        result.push(sum)
    }

    console.log(result.join(' '))
}

kNumbers(8,2)