function fruit(fruitName, weightInGrams, pricePerKg){
    let weightInKilos = weightInGrams / 1000;
    let moneyNeed = weightInKilos * pricePerKg;

    console.log(`I need $${moneyNeed.toFixed(2)} to buy ${weightInKilos.toFixed(2)} kilograms ${fruitName}.`);
}

fruit('orange', 2500, 1.80);