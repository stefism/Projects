let map = new Map();
map.set('one', 1);
map.set('ten', 10);
map.set('eight', 8);
map.set('two', 2);

let arrayFromMap = Array.from(map.entries());
arrayFromMap.sort((a, b) => a[1] - b[1]);

console.log(arrayFromMap); // [ [ 'one', 1 ], [ 'two', 2 ], [ 'eight', 8 ], [ 'ten', 10 ] ]

// Обръщане на масив от масиви, отново на Map()
let orderedMap = new Map(arrayFromMap);
console.log(orderedMap); // Map(4) { 'one' => 1, 'two' => 2, 'eight' => 8, 'ten' => 10 }