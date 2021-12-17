function fly() {
    console.log(`${this.name} is flying.`);
}

fly(); // undefined is flying.

let contextObject = {
    name: 'Wonder Woman'
};

fly.call(contextObject); // Wonder Woman is flying.
// То ще си търси само пропертито с това име от текущия обект, който е зададен като контекст на функцията. Не се подава contextObject.name, а направо цели обект, който е явява контекст в случая.