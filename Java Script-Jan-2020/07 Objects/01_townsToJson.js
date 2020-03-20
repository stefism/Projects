function townsToJson(input) {
    let output = []

    for (let i = 1; i < input.length; i++) {
        let currentData = input[i].split(' | ')

        let currentTown = currentData[0].slice(2)
        let currentLatitude = +currentData[1]
        let currentLongitude = +currentData[2].slice(0, currentData[2].length-2)

        let currentObject = {
            Town: currentTown,
            Latitude: +currentLatitude.toFixed(2),
            Longitude: +currentLongitude.toFixed(2)
        }

        output.push(currentObject)
    }

    let jsonOutput = JSON.stringify(output)

    return jsonOutput
}

console.log(townsToJson([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
    ]
))