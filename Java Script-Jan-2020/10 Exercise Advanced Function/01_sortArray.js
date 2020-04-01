function sortArray(array, sort) {
    if(sort === 'asc'){
        array.sort((a, b) => a-b)
    } else {
        array.sort((a, b) => b-a)
    }

    return array
}

console.log(sortArray([14, 7, 17, 6, 8], 'asc'))