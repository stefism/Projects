function sortArray(array, sort) {
    let inputArray = array.slice();

    if(sort =='asc') {
        inputArray.sort((a, b) => a - b);
    } else {
        inputArray.sort((a, b) => b - a);
    }

    return inputArray;
}

console.log(sortArray([14, 7, 17, 6, 8], 'desc'));;