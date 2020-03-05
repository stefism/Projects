function aggregate(arr, func){
    return func(arr);
}

function sum(arr){
    let result = 0;

    for (let index = 0; index < arr.length; index++) {
        const element = arr[index];
        result += element;
    }

    return result;
}

function inverseSum(arr){
    let result = 0;

    for (let index = 0; index < arr.length; index++) {
        const element =  1 / arr[index];
        result += element;
    }

    return result;
}

function concat(arr){
    let result = '';

    for (let index = 0; index < arr.length; index++) {
        const element =  arr[index];
        result += element;
    }

    return result;
}

console.log(aggregate([1, 4, 7], sum));
console.log(aggregate([1, 2, 4], inverseSum));
console.log(aggregate([1, 2, 4], concat));