function cappyJuice(input) {
    let juices = {}
    let bottles = {}

    input.forEach((line) => {
        let [name, quantity] = line.split(' => ')
        quantity = Number(quantity)

        if(!juices.hasOwnProperty(name)){
            juices[name] = 0
        }

        juices[name] += quantity

        let currentQuantity = juices[name]

        if (currentQuantity >= 1000){
            bottles[name] = Math.trunc(currentQuantity / 1000)
        }
    })

    let output = ''

    for(let product in bottles){
        output += `${product} => ${bottles[product]}\n`
    }

    return output.trim()
}

console.log(cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
))