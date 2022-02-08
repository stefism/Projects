let person = { name: 'Pesho Goshev', age: 22 };

let employee = Object.create(person); //Ще създаде празен обект, без пропертита, който ще има за прототип Person.
console.log(employee.__proto__); //{name: 'Pesho Goshev', age: 22}

let employee2 = Object.assign({}, person); //Ще направи нов обект, като ще изкопира в него всички пропертита от person, но този обект ще има празен прототип.
console.log(employee2.__proto__); //[Object: null prototype] {}