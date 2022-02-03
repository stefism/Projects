let person = {
    name: 'Pesho',
    age: 20,
    hobby: 'footbal'
};

//Add not numerable property
Object.defineProperty(person, 'grades', {
    enumerable: false,
    value: [2, 3, 4, 5]
});

//Change existing property
Object.defineProperty(person, 'hobby', {
    enumerable: false
});

for (const prop in person) {
    console.log(`${prop} -> ${person[prop]}`);
}

// result:
//name -> Pesho
//age -> 20
// Пропертитата ги има но не се итерират от фор ин цикъла.

console.log(person.grades);

Object.defineProperties(person, {
    name: {
        enumerable: true
    },
    hobby: {
        enumerable: true
    }
}); //Няколко пропертита на един път.

//Взимате на вътрешните пропертита на пропертито в обекта
let descriptor = Object.getOwnPropertyDescriptor(person, 'grades');
console.log(descriptor);
// {
//     value: [ 2, 3, 4, 5 ],
//     writable: false,
//     enumerable: false,
//     configurable: false
//   }

// writable: false, - прави пропертито на обекта read only.

Object.defineProperty(person, 'name', { writable: false });
person.name = 'Gosho';
console.log(person.name); // Pesho
//Не можем да му сменим името щото сме му казали на това проперти да е read only.

delete person.name; //Премахва проперти.
console.log(person); //{age: 20, hobby: 'footbal', grades: Array(4)}
