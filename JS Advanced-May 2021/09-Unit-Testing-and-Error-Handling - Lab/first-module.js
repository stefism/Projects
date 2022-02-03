let name = 'Pesho';
let sayHello = () => {
    console.log('Hello');
};

sayHello();
console.log(name);

module.exports = 'Gosho'; //Така, когато влезе в този файл и ще изпълни всичко от файла ред по ред.

module.exports = {
    getName: () => name,
    sayHello
}; //Така в second-module ще е достъпно само това, което тук сме експортнали.
// Може да имаме много импорти, но така написано, можем да имаме само един експорт.