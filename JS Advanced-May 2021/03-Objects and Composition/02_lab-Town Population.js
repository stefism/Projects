function townPopulation(input){
    let cities = {};

    input.forEach(e => {
        let [city, population] = e.split(" <-> ");

        if (cities[city]) {
            cities[city] += Number(population)
        } else {
            cities[city] = Number(population);
        }
    });
 

    for(let city in cities){
        console.log(`${city} : ${cities[city]}`);
    }
}

townPopulation([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
]);