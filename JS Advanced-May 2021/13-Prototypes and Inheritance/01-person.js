class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    }

    set fullName(value) {
        let [firstName, lastName] = value.split(' ');

        if(lastName != undefined && lastName != '') {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

//Function constructor - конструктор функция. Връща обект. Работи като класовете.
function Person2(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', { // this e -> на обекта който ще върнем, му дефинираме ново проперти fullName.
        get: function() {
            return `${this.firstName} ${this.lastName}`;
        },
        set: function(value) {
            // let [fName, lName] = value.split(' ');

            // if(lName != undefined && lName != '') {
            //     this.firstName = fName;
            //     this.lastName = lName;
            // }

            const pattern = /(?<firstName>\w+) (?<lastName>\w+)/;
            let matchResult = value.match(pattern);

            if(matchResult) {
                this.firstName = matchResult.groups.firstName;
                this.lastName = matchResult.groups.lastName;
            }
        }
    }); //this нормално сочи към контекста на една функция, но когато я викаме функцията с new от пред, тогава функцията връща обект и this ще сочи към върнатия обект.
}

let person = new Person2("Peter", "Ivanov");
console.log(person.fullName);
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla
console.log(person.fullName);
