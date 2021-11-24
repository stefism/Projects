function storeCatalogue(input){
    let result = [];

    input.forEach(element => {
        let firstLetter = element.charAt(0);
        console.log(result[firstLetter]);
        if (result.some(r => r[firstLetter] == firstLetter)) {
            console.log(result[firstLetter]);
        }
        else {
            let curr = {
                [firstLetter]: [element]
            }
            result.push(curr);
        }
    });

    let keys = Object.keys(result);
    console.log(keys);

    console.log(result);
}

storeCatalogue([
'Appricot : 20.4',
'Anti-Bug Spray : 15',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'T-Shirt : 10']
);