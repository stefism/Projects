function storeCatalogue(input){
    let result = [];

    input.forEach(element => {
        let firstLetter = element.charAt(0);
        if (result[firstLetter]) {
            result[firstLetter].push(element);
        }
        else {
            result[firstLetter] = [element]
        }
    });

    for(let item in result){
        console.log(item, result[item]);
    }

    let sort = result.sort((a, b) => a.localeCompare(b));

    console.log(sort);
}

function solve(input) {
    let items = [];

    input.forEach(element => {
        let [name, price] = element.split(" : ");
        
        let curr = {
            name,
            price
        }
        
        items.push(curr);
    });

    items.sort((a, b) => a.name.localeCompare(b.name));
    
    let result = '';
    let firstLetter = items[0].name.charAt(0);
    result += `${firstLetter}\n`;

    items.forEach(element => {
        let currFirstLetter = element.name.charAt(0);

        if(currFirstLetter != firstLetter) {
            result += `${currFirstLetter}\n`;
            firstLetter = currFirstLetter;
        }

        result += `${element.name}: ${element.price}\n`;
    });

    console.log(result);
}

function solve2(input){
    let dictionary ={}; //Като напишеш обекта и новото му проперти, то автоматично се добавя към обекта.
    while (input.length) {
        let [name, price] = input.shift().split(' : ');
        const firstLetter = name[0];

        if (!dictionary[firstLetter]) {
            dictionary[firstLetter] = [];
        }

        dictionary[firstLetter].push({name, price});
        dictionary[firstLetter].sort((a, b) => (a.name).localeCompare(b.name));
    }

    let result =[];

    // for(const letter in dictionary){
    //     let values = dictionary[letter].map(entry => `  ${entry.name}: ${entry.price}`);
    //     let string = `${letter}\n${values.join('\n')}`;
    //     result.push(string);
    // }

    // Object.entries -> [['key', value]]
    Object.entries(dictionary)
        .sort((a, b) => a[0].localeCompare(b[0])) //Тук сортираме по заглавната буква.
        .forEach(entry =>{
            let values = entry[1] //Тук взимаме стойностите към главната буква.
            .sort((a, b) => (a.name).localeCompare(b.name))
            .map(product => `  ${product.name}: ${product.price}`)
            .join('\n');

            let string = `${entry[0]}\n${values}`;
            result.push(string);
        });

    console.log(dictionary);
}

solve2([
'Appricot : 20.4',
'Anti-Bug Spray : 15',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'T-Shirt : 10']
);