let cars = ["BMV", "Audi", "Opel", "Honda"];
cars.fill("Car", 1, 3); //Запълни с нещо (това дето е на първо място) масива, като започнеш от индекс едно, до индекс 3, но не включително 3. Демек ще сложи "Кар" на индекс 1 и 2.
console.log(cars); //['BMV', 'Car', 'Car', 'Honda']

cars = ["BMV", "Audi", "Opel", "Honda", "aston"];
cars.reverse();
console.log(cars); //['Honda', 'Opel', 'Audi', 'BMV']

cars.sort(); //Сортира по ASCII таблицата. За да соритра различно му трябва сортираща функция да се подаде.

cars.sort((a, b) => a - b); //това е за числа.
cars.sort((a, b) => a.localeCompare(b)); //Лексикографски сортира стрингове по възходящ ред.
console.log(cars);