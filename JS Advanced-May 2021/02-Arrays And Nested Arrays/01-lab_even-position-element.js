function evenPositionElement(array){
    for (let i = 0; i < array.length; i += 2) {
        console.log(array[i]);
    }
}

evenPositionElement(['20', '30', '40', '50', '60']);