function lowestPricesInCities(input){
    let cities = [];
 
    input.forEach(city => {
        let [town, product, price] = city.split(" | ");

        let currCity = {
            town, 
            product, 
            price: Number(price)
        }

        cities.push(currCity);
    });

    cities.sort((a, b) => {
        if (a.product.localeCompare(b.product) == 0) {
            return a.price - b.price
        }

        return a.product.localeCompare(b.product);
    });

    let result = `${cities[0].product} -> ${cities[0].price} (${cities[0].town})\n`;
    let product = cities[0].product;

    for (let i = 1; i < cities.length; i++) {
        if (cities[i].product == product) {
            continue;
        }

        result += `${cities[i].product} -> ${cities[i].price} (${cities[i].town})\n`;
        product = cities[i].product;
    }

    console.log(cities);
    console.log(result);
}

function solve2(input) {
    let cities = [];

    input.forEach(city => {
        let [town, product, price] = city.split(" | ");

        let currCity = {
            town, 
            product, 
            price: Number(price)
        }
        
        if (cities.some(c => c.product == product)) {
            let index = cities.findIndex(c => c.product == product);
            
            if (cities[index].price > price) {
                cities[index].town = town;
                cities[index].product = product;
                cities[index].price = price;
            }
        } else {
            cities.push(currCity);
        }        
    });

    let result = '';

    cities.forEach(city => {
        result += `${city.product} -> ${city.price} (${city.town})\n`;
    });

    console.log(result);  
}

solve2(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);