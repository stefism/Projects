function sortingNumbers(array){
    let result = [];

    while (array.length > 0) {
        let min = Math.min.apply(Math, array);
        let max = Math.max.apply(Math, array);

        result.push(min);
        result.push(max);

        let minIndex = array.indexOf(min);
        array.splice(minIndex, 1);

        let maxIndex = array.indexOf(max);
        array.splice(maxIndex, 1);
    }

    return result;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));


function sortingNumbers2(array) {
    array.sort((a, b) => a-b);

    let result = [];

    while (array.length > 0) {
        let min = array.shift();
        let max = array.pop();

        result.push(min, max);
    }

    return result;
}

console.log(sortingNumbers2([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));