// Syntax, Functions and Statements - Lab
// https://judge.softuni.org/Contests/Practice/Index/2749#1

//01. Echo Function
function echo(string){
    console.log(string.length);
    console.log(string);
}

// echo("test")

//02. String Length
function length(firstStrting, secondString, thirdString){
    let totalStringsLength = firstStrting.length + secondString.length + thirdString.length;
    console.log(totalStringsLength);

    let averageLength = Math.floor(totalStringsLength / 3);
    console.log(averageLength);
}

// length('chocolate', 'ice cream', 'cake')

//03. Largest Number
function largestNumber(n1, n2, n3){
    let largest = Math.max(n1, n2, n3);

    console.log(`The largest number is ${largest}.`);
}

function largestNumber2(...params){
    let largestNumber = Math.max(...params);

    console.log(`The largest number is ${largestNumber}.`);
}

largestNumber(7, 11, 2);
largestNumber(7, 8, 15, 11, 12);