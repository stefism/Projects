function calculateMoney(fruit, grams, pricePerKg){
    let kilos = (grams / 1000);
    let needMoney = (kilos * pricePerKg);

    console.log(`I need $${needMoney.toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`);
}

calculateMoney('apple', 1563, 2.35);