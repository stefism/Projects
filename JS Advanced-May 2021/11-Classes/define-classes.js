class Cat {
    constructor() {
        this.name = 'Pesho';
    }
}

class Cat2 {
    hunger = 100; // Това е проперти (поле) и затова нямаме през него let или const.

    constructor(name, breed) {
        this.name = name;
        this.breed = breed;
    }

    //get and set -> Accessor Properties
    get isHungry() {
        return this.hunger > 80; //Ако е по голямо от 80 ще върне true, ако е по-малко, ще върне false. Всеки път когато го извикаме това проперти, то ще влиза тук и ще изчислява и връща true или false.
    }

    //set се използва най-често за валидация.
    set isHungry(value) { //Value в случая е true или false.
        if(typeof value != 'boolean') {
            throw Error('Incorrect property type.');
        }

        if(value) {
            this.hunger = 100;
        } else {
            this.hunger = 0;
        }
    }

    makeSound() {
        console.log(`${this.name} - мяу.`);
    }

    static scratchWithNails() {
        console.log('Drapam s nokti.');
    }
}

let cat = new Cat();
cat.age = 10;
console.log(cat);

let cat2 = new Cat2('Kotkata', 'Porodista');
Cat2.scratchWithNails();
console.log(cat2.isHungry, cat2.hunger); // true 100
cat2.isHungry = false;
cat2.isHungry = 'La la la'; //Uncaught Error: Incorrect property type.
console.log(cat2.isHungry, cat2.hunger); // false 0

let cat3 = new Cat2('Kotkata2', 'Porodista2');
cat3.makeSound();

console.log(cat2, cat3);