function evenPositionElement(array){
    let evenArray = [];

    for (let i = 0; i < array.length; i += 2) {
        evenArray.push(array[i])  
    }

    console.log(...evenArray);
}

evenPositionElement(['20', '30', '40', '50', '60']);