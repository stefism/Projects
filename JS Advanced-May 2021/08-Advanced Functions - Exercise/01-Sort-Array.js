function sortArray(array, sort) {
    let inputArray = array.slice();

    if(sort =='asc') {
        inputArray.sort((a, b) => a - b);
    } else {
        inputArray.sort((a, b) => b - a);
    }

    return inputArray;
}

function sortArray2(array, type) {
    const sort = {
        'asc': (a, b) => a - b,
        'desc': (a, b) => b - a
    }

    return array.sort(sort[type]);
}

console.log(sortArray2([14, 7, 17, 6, 8], 'desc'));;