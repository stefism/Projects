function sumFirstLast(array){
    let first = parseInt(array.shift());
    let last = Number(array.pop());

    console.log(first + last);
}

sumFirstLast(['20', '30', '40']);