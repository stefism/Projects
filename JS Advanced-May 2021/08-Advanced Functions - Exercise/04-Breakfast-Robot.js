function breakfastRobot() {
    let microElements = { protein: 0, carbohydrate: 0, fat: 0, flavour: 0 }

    let products = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

    return function (instruction) {
        let [command, product, quantity] = instruction.split(' ');

        switch (command) {
            case 'restock':
                microElements[product] += Number(quantity);
                return 'Success';

            case 'prepare':
                let productToPrepare = products[product];
                prepareProduct(productToPrepare, quantity);
                return 'Success';

            case 'report':
                let result = '';
                for (const element in microElements) {
                    result += `${element}=${microElements[element]} `;
                }

                return result.trim();
        }
    }

    function prepareProduct(productToPrepare, quantity) {
        for (const product in productToPrepare) {
            let neededQuantity = productToPrepare[product] * quantity;
            if (microElements[product] >= neededQuantity) {
                continue;
            } else {
                return `Error: not enough ${product} in stock`;
            }
        }

        for (const product in productToPrepare) {
            let neededQuantity = productToPrepare[product] * quantity;
            microElements[product] -= neededQuantity;
        }
    }
}

let manager = breakfastRobot();
console.log(manager("restock flavour 50"));
console.log(manager("prepare lemonade 4"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));