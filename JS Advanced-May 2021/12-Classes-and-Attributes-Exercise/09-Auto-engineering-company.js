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

function carsWithClass(inputArray) {
    let cars = [];

    class Car {
        constructor(name, model, quantity, index) {
            this.name = name;
            this.model = model;
            this.quantity = quantity;
            this.index = index;
        }
    }

    inputArray.forEach((car, index) => {
        let [name, model, quantity] = car.split(' | ');

        if(cars.some(c => c.name == name)) {
            if(cars.some(c => c.model == model)) {
                let carIndex = cars.findIndex(c => c.model == model);
                cars[carIndex].quantity += Number(quantity);
            } else {
                let carIndex = cars.findIndex(c => c.name == name);
                let currCar = new Car(name, model, Number(quantity), cars[carIndex].index);
                cars.push(currCar);
            }
        } else {
            let currCar = new Car(name, model, Number(quantity), index);
            cars.push(currCar);
        }
    });

    cars.sort((a, b) => a.index - b.index);

    let result = '';
    let currName = '';

    cars.forEach(car => { 
        if(car.name == currName) {
            result += `###${car.model} -> ${car.quantity}\n`;
            
        } else {
            result += `${car.name}\n`;
            result += `###${car.model} -> ${car.quantity}\n`;
        
            currName = car.name;
        }
    });

    console.log(result);
}

function carsWithMap(arr) {
    let split = [];

    for(let i = 0; i < arr.length; i++) {
        split.push(arr[i].split(' | '))
    }

    let storage = new Map();

    for(let i = 0; i < split.length; i++) {
        let cars = split[i];

        let [brand, model, quantity] = cars;

        if(!storage.has(brand)) {
            storage.set(brand, new Map());
        }

        if(!storage.get(brand).has(model)) {
            storage.get(brand).set(model, 0);
        }

        let value = Number(storage.get(brand).get(model));
        storage.get(brand).set(model, value + Number(quantity));
    }

    let resultString = [];

    for(let [brand, model] of storage.entries()) {
        let result = `${brand}\n`;

        for(let [name, quantity] of model.entries()) {
            result += `###${name} -> ${quantity}\n`;
        }

        resultString.push(result.trim());
    }

    return resultString.join('\n');
}

console.log(carsWithMap(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
));