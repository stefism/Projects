function autoEngineeringCompany(input) {
    let catalogue = {}

    for(let line of input){
        let [carBrand, carModel, producedCars] = line.split(' | ')
        producedCars = Number(producedCars)

        if(!catalogue.hasOwnProperty(carBrand)){
            catalogue[carBrand] = {}
        }

        let carModels = catalogue[carBrand]

        if(!carModels.hasOwnProperty(carModel)){
            carModels[carModel] = 0
        }

        carModels[carModel] += producedCars
    }

    let output = ''

    for(let carBrand in catalogue){
        output += `${carBrand}\n`

        let carModels = catalogue[carBrand]

        for(let carModel in carModels){
            output += `###${carModel} -> ${carModels[carModel]}\n`
        }
    }

    return output.trim()
}

console.log(autoEngineeringCompany(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
))