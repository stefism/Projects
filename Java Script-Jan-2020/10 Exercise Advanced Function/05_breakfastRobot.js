function solution(){
    let products = {
        fat: 0,
        flavour: 0,
        protein: 0,
        carbohydrate: 0
    }

    return function (data) {
        let [command, product, quantity] = data.split(' ')
        quantity = Number(quantity)

        let notEnoughProducts = []

        if(command === 'restock'){
            products[product] += quantity
            console.log('Success')

        } else if(command === 'prepare'){
            collectNotEnoughProduct(product, quantity)

            if(notEnoughProducts.length > 0){
                return console.log(`Error: not enough ${notEnoughProducts.join(', ')} in stock`)
            }

            switch (product) {
                case 'turkey':
                    product.protein -= quantity * 10
                    products.fat -= quantity * 10
                    products.carbohydrate -= quantity * 10
                    products.flavour -= quantity * 10
                    break

                case 'eggs':
                    products.protein -= quantity * 5
                    products.fat -= quantity
                    products.flavour -= quantity
                    break

                case 'burger':
                    products.carbohydrate -= quantity * 5
                    products.fat -= quantity * 7
                    products.flavour -= quantity * 3
                    break

                case 'lemonade':
                    products.carbohydrate -= quantity * 10
                    products.flavour -= quantity * 20
                    break

                case 'apple':
                    products.carbohydrate -= quantity
                    products.flavour -= quantity * 2
                    break
            }

            console.log('Success')

        } else {
            console.log(products)
        }

        function collectNotEnoughProduct(product, quantity) {
            switch (product) {
                case 'turkey':
                    if(products.protein < quantity * 10){
                        notEnoughProducts.push('protein')
                    }
                    if(products.fat < quantity * 10){
                        notEnoughProducts.push('fat')
                    }
                    if(products.carbohydrate < quantity * 10){
                        notEnoughProducts.push('carbohydrate')
                    }
                    if(products.flavour < quantity * 10){
                        notEnoughProducts.push('flavour')
                    }
                    break

                case 'eggs':
                    if(products.protein < quantity * 5){
                        notEnoughProducts.push('protein')
                    }
                    if (products.fat < quantity){
                        notEnoughProducts.push('fat')
                    }
                    if(products.flavour < quantity){
                        notEnoughProducts.push('flavour')
                    }
                    break

                case 'burger':
                    if(products.carbohydrate < quantity * 5){
                        notEnoughProducts.push('carbohydrate')
                    }
                    if(products.fat < quantity * 7){
                        notEnoughProducts.push('fat')
                    }
                    if(products.flavour < quantity * 3){
                        notEnoughProducts.push('flavour')
                    }
                    break

                case 'lemonade':
                    if(products.carbohydrate < quantity * 10){
                        notEnoughProducts.push('carbohydrate')
                    }
                    if(products.flavour < quantity * 20){
                        notEnoughProducts.push('flavour')
                    }
                    break

                case 'apple':
                    if(products.carbohydrate < quantity){
                        notEnoughProducts.push('carbohydrate')
                    }
                    if(products.flavour < quantity * 2){
                        notEnoughProducts.push('flavour')
                    }
                    break
            }
        }
    }
}

let manager = solution()
manager('restock carbohydrate 10')
manager('restock flavour 10')
manager('prepare apple 1')
manager('restock fat 10')
manager('prepare burger 1')
manager('report')