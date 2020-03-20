function  cityMarkets(input) {
    let output = []

    for (let i = 0; i < input.length; i++) {
        let obj = {}
        let data = input[i].split(' -> ')

        let city = data[0]
        let product = '$$$'+data[1]

        let numbers = data[2].split(':')
        let price = +numbers[0]
        let quantity = +numbers[1]
        let totalPrice = price * quantity

        let townElement = `${product}:${totalPrice}`

        if(typeof obj.Town === 'undefined'){
            obj.Town = city
            obj.Elements = []
            obj.Elements.push(townElement)
            debugger
        }
        //obj[city] =
    }
}

console.log(cityMarkets(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
))