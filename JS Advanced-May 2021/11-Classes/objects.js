let numbers = {
    'one': 1,
    'ten': 10,
    'eight': 8,
    'two': 2
}

let keys = Object.keys(numbers);
console.log(keys); // ['one', 'ten', 'eight', 'two']

let values = Object.values(numbers);
console.log(values); // [1, 10, 8, 2]

let entries = Object.entries(numbers);
console.log(entries); // [ [ 'one', 1 ], [ 'ten', 10 ], [ 'eight', 8 ], [ 'two', 2 ] ]

let sortedArray = Object.entries(numbers).sort((a, b) => a[1] - b[1]);
console.log(sortedArray); // [ [ 'one', 1 ], [ 'two', 2 ], [ 'eight', 8 ], [ 'ten', 10 ] ]

// Обръщане от масив от масиви в отново в обект
let sortedObject = Object.fromEntries(sortedArray);
console.log(sortedObject); // { one: 1, two: 2, eight: 8, ten: 10 }