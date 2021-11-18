let cars = ["BMV", "Audi", "Opel", "Edna", "Dve", "Tri", "Opel dve"];

let filter = cars.filter(c => c.startsWith('O'));
console.log(filter); //['Opel', 'Opel dve']

let map = cars.map(c => c.toLocaleLowerCase());
console.log(map); //['bmv', 'audi', 'opel', 'edna', 'dve', 'tri', 'opel dve']

let cars2 = ["BMV", "Audi", undefined, "Edna", "Dve", undefined, "Opel dve"];
let join = cars2
    .filter(c => c != undefined) //Може да се напише съкратено и (c => c)
    .join();

console.log(join);