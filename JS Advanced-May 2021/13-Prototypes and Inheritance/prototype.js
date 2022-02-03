let person = { name: 'Pesho Goshev', age: 22 };
let employee = { employeeId: 12, department: 'development'};

Object.setPrototypeOf(employee, person);

for (const key in employee) {
    if (employee.hasOwnProperty(key)) {
        console.log('Own property -> ' + key);
    } else {
        console.log('Prototype property -> ' + key);
    }
}

// Own property -> employeeId
// Own property -> department
// Prototype property -> name
// Prototype property -> age

function Person(name, age) {
    this.name = name;
    this.age = age;
    // this.greet = function() {
    //     console.log(`My name is ${this.name}`);
    // }; Не се слага тука защото така всяка инстанция на Person ще прави нова собствена функция и ще заема повече място в паметта.
}

Person.prototype.greet = function() {
    console.log(`My name is ${this.name}`);
}; // Слага се в прототипа и така ще се направи само една инстанция на тази функция, която ще се ползва от всички инстанции на Person.
let person1 = new Person('Pesho', 20);
let person2 = new Person('Gosho', 22);

person1.greet(); // My name is Pesho
person2.greet(); // My name is Gosho