//Map - записва ключ - стойност (key - value).
let map = new Map();
map.set('name', 'Pesho');
map.set('age', 20);

console.log(map.get('name')); // Pesho
console.log(map.has('name')); // true
console.log(map.size);

map.delete('name');
map.clear(); // Remove all key-value pairs.
console.log(map.size);

let people = new Map();
people.set(100, 'Gosho');
people.set(200, 'Pesho');
people.set(300, 'Ivan');
people.set(400, 'Albena');
people.set(500, 'Anetka');

let keys = people.keys();
console.log(keys);

let values = people.values();
console.log(values);

for(const name of people.values()){
    console.log(name);
}

for (const number of people.keys()) {
    console.log(people.get(number));
}

console.log(people.entries());

for (const kvp of people.entries()) {
    // Връща масив от масиви
    console.log(`${kvp[0]} - ${kvp[1]}`);
}

for (const [key, value] of people.entries()) {
    // Връща масив от масиви
    console.log(`${key} - ${value}`);
}

// Във Map можем да слагаме каквото си поискаме за ключ (или стойност), включително и обект.
let employeeMap = new Map();

let pesho = {name: 'Pesho', age: 20};

employeeMap.set(pesho, 'Programmer');
employeeMap.set({name: 'Ginka', age: 18}, 'Manager');

console.log(employeeMap); // {
    //      { name: 'Pesho', age: 20 } => 'Programmer',
    //      { name: 'Ginka', age: 18 } => 'Manager'
  //    }

  //WeakMap and WeakSet - Out-of-scope references are removed by the garbage collector.