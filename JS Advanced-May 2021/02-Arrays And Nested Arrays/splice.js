// splice - Връща масив със изрязаните елементи.
let cars = ["BMV", "Audi", "Opel"];

cars.splice(1, 0, "Mercedes"); //Постави на първа позиция "Мерцедес" (1), като не трий нищо (нула елемента изтрий) (0). Можем и повече от един елемент да поставяме.

console.log(cars); //['BMV', 'Mercedes', 'Audi', 'Opel']

let cars2 = ["BMV", "Audi", "Opel", "Honda"];

cars2.splice(2); //Махни всичко от втория индекс на татъка.+
console.log(cars2); //['BMV', 'Audi']


let cars3 = ["BMV", "Audi", "Opel", "Honda"];
cars3.splice(2, 1); //Махни от втора позиция, един елемент. cars3.splice(2, 2) Ще премахне два елемента от втория индекс нататък.
console.log(cars3); //['BMV', 'Audi', 'Honda']

let cars4 = ["BMV", "Audi", "Opel", "Honda"];
cars4.splice(1, 2, "Car1", "Car2"); //От първи индекс натам, махни 2 елемента и в същото време постави 2 елемента пак от първи индекс нататък.
console.log(cars4); //['BMV', 'Car1', 'Car2', 'Honda']