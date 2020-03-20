function populationInTowns(input) {
    let outputObject = {}

    for (let i = 0; i < input.length; i++) {
        let data = input[i].split(' <-> ')

        let town = data[0]
        let population = +data[1]

        if(typeof outputObject[town] === 'undefined'){
            outputObject[town] = 0
        }

        outputObject[town] += population
    }

    let outputString = ''

    for(let city in outputObject){
        outputString += `${city} : ${outputObject[city]}\n`
    }

    return outputString
}

console.log(populationInTowns(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
))