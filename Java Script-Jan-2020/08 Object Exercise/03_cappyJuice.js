function cappyJuice(input) {
    let obj = {}

    for(let line of input){
        let [juiceName, quantity] = line.split(' => ')
        quantity = Number(quantity)

        if(typeof obj[juiceName] === 'undefined'){
            obj[juiceName] = 0
        }

        obj[juiceName] += quantity
    }

    for(prop in obj){
        obj[prop] = Math.floor(obj[prop] / 1000)
    }

    let output = ''

    for(prop in obj){
        if(obj[prop] > 0){
            output += `${prop} => ${obj[prop]}\n`
        }
    }

    return output
}

console.log(cappyJuice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
))