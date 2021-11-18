let numbers = [20, 10, 5, 30, 8, 7];

function sumNumbers(accumulator, current) {
    return accumulator + current;
}

let sum = numbers.reduce(sumNumbers, 0); //0 - указваме му начална стойност.

let sum2 = numbers.reduce(function(acc, curr) {
    return acc + curr;
}, 0);

let sum3 = numbers.reduce((a, c) => a + c, 0);

console.log(sum3);

let average = numbers.reduce((acc, curr, index, array) => {
    return acc + (curr / array.length);
}, 0); //Да не забравяме да сложим началната стойност на акумулатора. Стартовата стойност може и да е масив. array е референция към текущия масив върху който работим.

console.log(average);

let evenNumbers = numbers.reduce((a, c) => {
    if (c % 2 == 0) {
        a.push(c);
    }

    return a;
}, []);

console.log(evenNumbers);