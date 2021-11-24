function carFactory(carObject){
    let resultCar = {
        model: carObject.model,
        engine: calculateEngine(carObject.power),
        carriage: {
            type: carObject.carriage,
            color: carObject.color
        },
        wheels: calculateWheelsDiameter(carObject.wheelsize)
    };

    return resultCar;

    function calculateWheelsDiameter(wheelSize){
        if (wheelSize % 2 == 0) {
            return Array(4).fill(wheelSize - 1, 0, 4);
        }
        
        return Array(4).fill(wheelSize, 0, 4);
    }

    function calculateEngine(power){
        if (power <= 90) {
            return {
                power: 90,
                volume: 1800
            };

        } else if (power > 90 && power <= 120) {
            return {
                power: 120,
                volume: 2400
            };

        } else if (power > 120 && power <= 200) {
            return {
                power: 200,
                volume: 3500
            };
        }
    }
}

console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
    }));