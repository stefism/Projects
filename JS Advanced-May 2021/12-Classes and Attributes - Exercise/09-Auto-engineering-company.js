function cars(inputArray) {
    let cars = {};

    let carPr = {
        "Audi": {
            "Q7": 20,
            "Q6": 30
        },
        "BMW": {
            "X5": 15,
            "X6": 35
        },
    };

    inputArray.forEach(car => {
        let [name, model, quantity] = car.split(' | ');

        if (cars[name]) {
            if(cars[name][model]) {
                cars[name][model] += Number(quantity);
            } else {
                cars[name][model] = Number(quantity);
            }
        } else {
            cars[name] = {
                [model]: Number(quantity) 
            }
        }
    });

    let output = '';

    for(const car in cars) {
        output += `${car}\n`;

        for(const model in cars[car]) {
            output += `###${model} -> ${cars[car][model]}\n`
        }
    }

    console.log(output);
}

cars(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);