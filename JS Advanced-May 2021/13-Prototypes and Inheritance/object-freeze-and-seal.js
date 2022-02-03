let cat = { name: 'Tom', age: 5 };

console.log(Object.getOwnPropertyDescriptors(cat));
// name: {
//     value: 'Tom',
//     writable: true,
//     enumerable: true,
//     configurable: true
//   },
//   age: { value: 5, writable: true, enumerable: true, configurable: true }

Object.freeze(cat);

console.log(Object.getOwnPropertyDescriptors(cat));
// name: {
//     value: 'Tom',
//     writable: false,
//     enumerable: true,
//     configurable: false
//   },
//   age: { value: 5, writable: false, enumerable: true, configurable: false }

Object.seal(cat); //Променя на пропертитата само configurable да е false.