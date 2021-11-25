function townsToJson(input){
    let result =[];
    let [properties, ...towns] = input;
    let [townProp, latitudeProp, longitudeProp] = properties.split(" | ");
    townProp = townProp.substring(2);
    longitudeProp = longitudeProp.slice(0, -2);

    towns.forEach(element => {
        let [town, latitude, longitude] = element.split(" | ");
        town = town.substring(2);
        longitude = longitude.slice(0, -2);

        let currTown = {
            [townProp]: town,
            [latitudeProp]: Number(Number(latitude).toFixed(2)),
            [longitudeProp]: Number(Number(longitude).toFixed(2))
        }

        result.push(currTown);
    });

    console.log(JSON.stringify(result));
}

function townsToJson2(input){
    let[columns, ...table] = input.map(splitLine);

    function isEmptyString(x) {
        return x !== "";
    }

    function convertIfNum(x) {
        return isNaN(x) ? x : Number(Number(x).toFixed(2));
    }

    function splitLine(input) {
        return input.split(' | ')
            .filter(isEmptyString)
            .map(x => x.trim())
            .map(convertIfNum);
    }

    return JSON.stringify(table.map(entry => {
        return columns.reduce((acc, curr, index) => {
            acc[curr] = entry[index];
            return acc;
        }, {});
    }));
}

console.log(townsToJson2(['| Town | Latitude | Longitude | Pesho',
'| Sofia | 42.696552 | 23.32601 | dddd',
'| Beijing | 39.913818 | 116.363625 | dddd']));