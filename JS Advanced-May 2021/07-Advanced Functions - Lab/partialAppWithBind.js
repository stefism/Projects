function greet(name, message) {
    console.log(`Hey ${name}, ${message}`);
}

let greetMariya = function(message) {
    greet('Mariya', message)
}

let greetMariya2 = greet.bind(null, 'Mariya'); // По-правилен начин от горния (greetMariya).
// В случая нямаме контекст, затова му задаваме null и задаваме първия параметър. Bind ще върне нова функция с имплементиран първи параметър (Mariya) и след това като я викнем си подаваме втория, който е съобщението.

greetMariya('How are you?');
greetMariya2('How are you?');