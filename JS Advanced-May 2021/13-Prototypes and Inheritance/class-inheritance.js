class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    greet() {
        console.log(`My name is ${this.name}`);
    }
}

class Employee extends Person {
    constructor(name, age, department, id) {
        super(name, age); //super -> Сетни ги тези от Person

        this.department = department;
        this.id = id;
    }

    showId() {
        console.log(`Name ${this.name} has Id number ${this.id}`);
    }
}

let person = new Person('Gosho', 10);
let employee = new Employee('Pesho', 20, 'It', 111);

person.greet(); //My name is Gosho
employee.greet(); //My name is Pesho
employee.showId(); //Name Pesho has Id number 111