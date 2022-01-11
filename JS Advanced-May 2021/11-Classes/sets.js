let uniqueNumbers = new Set();

uniqueNumbers.add(2);
uniqueNumbers.add(5);
uniqueNumbers.add(2);
uniqueNumbers.add(6);
uniqueNumbers.add(7);

console.log(uniqueNumbers); // {2, 5, 6, 7}
console.log(uniqueNumbers.has(5)); // true

// Не е баш масив и ако искаме да го направим на чист масив;
let numbersArray = [...uniqueNumbers]; // ... работи върху всичко, което може да се итерира.
console.log(numbersArray); // [2, 5, 6, 7]