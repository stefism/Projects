let cars = ["BMV", "Audi", "Opel"];
let cars2 = ["Honda"];

let allCars = cars.concat(cars2);
console.log(allCars); //['BMV', 'Audi', 'Opel', 'Honda']

let joinedCars = allCars.join(); //Произвежда един стринг от всички елементи на масива, като дефолтно ги разделя със запетая.
console.log(joinedCars); //"BMV,Audi,Opel,Honda"

let cars3 = ["BMV", "Audi", "Opel", "Edna", "Dve", "Tri"];
let slice = cars3.slice(0, 3); //От кой индекс да започне и до кой индекс да вземе (не е включително).
console.log(slice); //['BMV', 'Audi', 'Opel'] Можем да си правим копие на масива така. Ако не му зададем начало и край, тогава взима от началото до края.

let isCarWithA = cars3.some((car) => {
    return car[0] == "A";
}); //Returns true or false depend of any condition.

let shortVariant = cars3.some(car => car[0] == 'A');
let find = cars3.find(car => car[0] == 'A'); //Audi. Ако намери, го връща.

console.log(isCarWithA);
console.log(find);