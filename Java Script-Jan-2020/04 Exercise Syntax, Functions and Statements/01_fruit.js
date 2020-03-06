function calculateMoney(fruit, grams, pricePerKg){
    let kilos = (grams / 1000).toFixed(2);
    let needMoney = (kilos * pricePerKg).toFixed(2);

    console.log(`I need $${needMoney} to buy ${kilos} kilograms ${fruit}.`);
}

calculateMoney('apple', 1563, 2.35);