function solution(){
    let products = {
        fat: 0,
        flavour: 0,
        protein: 0,
        carbohydrate: 0
    }

    return function (data) {
        let [command, product, quantity] = data.split(' ')

        if(command === 'restock'){
            products[product] += quantity

        } else if(command === 'prepare'){

            if(!isEnoughProducts(product, quantity)){
                return console.log('')
            }

            switch (product) {
                case 'turkey':

                    break
            }
        }

        function isEnoughProducts(product, quantity) {
            let isEnough = false

            switch (product) {
                case 'turkey':
                    if(products.protein >= quantity * 10
                        && products.carbohydrate >= quantity * 10
                        && products.fat >= quantity * 10
                        && products.flavour >= quantity * 10){
                        isEnough = true
                    }
                    break

                case 'eggs':
                    if(products.protein >= quantity * 5
                        && products.fat >= quantity
                        && products.flavour >= quantity){
                        isEnough = true
                    }
                    break

                case 'burger':
                    if(products.carbohydrate >= quantity * 5
                        && products.fat >= quantity * 7
                        && products.flavour >= quantity * 3){
                        isEnough = true
                    }
                    break

                case 'lemonade':
                    if(products.carbohydrate >= quantity * 10
                        && products.flavour >= quantity * 20){
                        isEnough = true
                    }
                    break

                case 'apple':
                    if(products.carbohydrate >= quantity
                        && products.flavour >= quantity * 2){
                        isEnough = true
                    }
                    break
            }

            return isEnough
        }
    }
}

let manager = solution()
manager('restock flavour 50')
manager('prepare lemonade 4')