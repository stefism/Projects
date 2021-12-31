function subSum(array, startIndex, endIndex) {
    let isArray = Array.isArray(array);

    if (!isArray) {
        return NaN;
    }

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        
        if(isNaN(element)){
            return NaN;
        }
    }

    // array.forEach(element => {
    //     if(isNaN(element)){
    //         return NaN;
    //     }
    // });

    startIndex < 0 ? startIndex = 0 : startIndex;
    endIndex > array.length - 1 ? endIndex = array.length - 1 : endIndex;

    return array.slice(startIndex, endIndex + 1).reduce((acc, curr) => acc + curr, 0);
}

console.log(subSum([10, 'twenty', 30, 40], 0, 2));