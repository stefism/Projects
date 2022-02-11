class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw Error('Not enough parking space.');
        }

        let car = {
            [carNumber]: { carModel, payed: false }
        }
        
        this.vehicles.push(car);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    pay(carNumber) {
        let carIndex = this.vehicles.findIndex(car => car[carNumber]);
        if (carIndex == -1) {
            throw Error(`${carNumber} is not in the parking lot.`);
        }

        if (this.vehicles[carIndex][carNumber].payed) {
            throw Error(`${carNumber}'s driver has already payed his ticket.`)
        }

        this.vehicles[carIndex][carNumber].payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if(carNumber == undefined) {
            let result = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;

            this.vehicles.forEach(v => {
                let isPayed = Object.values(v)[0].payed ? 'Has payed' : 'Not payed';
                result += `${Object.values(v)[0].carModel} == ${Object.keys(v)[0]} - ${isPayed}\n`;
            });

            return result.trim();
        } else {
            let carIndex = this.vehicles.findIndex(car => car[carNumber]);
            let isPayed = Object.values(this.vehicles[carIndex])[0].isPayed ? 'Has payed' : 'Not payed';

            return `${Object.values(this.vehicles[carIndex])[0].carModel} == ${Object.keys(this.vehicles[carIndex])[0]} - ${isPayed}`;
        }
    }

    removeCar(carNumber) {
        let carIndex = this.vehicles.findIndex(car => car[carNumber]);
        if (carIndex == -1) {
            throw Error("The car, you're looking for, is not found.");
        }

        if (!this.vehicles[carIndex][carNumber].payed) {
            throw Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }

        this.vehicles.splice(carIndex, 1);
        return `${carNumber} left the parking lot.`;
    }
}

class Parking2 {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw Error('Not enough parking space.');
        }

        let car = {
            carModel,
            carNumber,
            payed: false
        }
        
        this.vehicles.push(car);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    pay(carNumber) {
        let currentCar = this.findCar(carNumber);
        
        if (!currentCar) {
            throw Error(`${carNumber} is not in the parking lot.`);
        }

        if (currentCar.payed) {
            throw Error(`${carNumber}'s driver has already payed his ticket.`)
        }

        currentCar.payed = true; //Няма проблем така, защото се променя по референция.
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        let currentCar = this.findCar(carNumber);

        if(carNumber == undefined) {
            let result = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;

            let sortedVehicles = this.vehicles
            .slice() //За да направим копие на масива. Не е добре да се манипулират директно входните данни.
            .sort((car1, car2) => car1.carModel.localeCompare(car2.carModel))
            .forEach(v => {
                result += this.carReport(v);
            });

            return result.trim();
        } else {
            return this.carReport(currentCar);
        }
    }

    removeCar(carNumber) {
        let currentCar = this.findCar(carNumber);
        
        if (!currentCar) {
            throw Error("The car, you're looking for, is not found.");
        }

        if (!currentCar.payed) {
            throw Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }

        this.vehicles = this.vehicles.filter(car => carNumber != carNumber);
        return `${carNumber} left the parking lot.`;
    }

    findCar(carNumber) {
        return this.vehicles.find(car => car.carNumber == carNumber); //Ако има такава кола, ще върне целия обект с тази кола.
    }

    carReport(currentCar) {
        return `${currentCar.carModel} == ${currentCar.carNumber} - ${currentCar.payed ? 'Has payed' : 'Not payed'}`;
    }
}

const parking = new Parking2(12);
console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));