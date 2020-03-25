function storeCatalogue(input) {
    let catalogue ={}

    for(let line of input){
        let [name, price] = line.split(' : ')
        price = Number(price)

        let initial = name[0]

        if(!catalogue.hasOwnProperty(initial)){
            catalogue[initial] = {}
        }

        let products = catalogue[initial]

        if(!products.hasOwnProperty(name)){
            products[name] = price
        }
    }
}

console.log(storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
))