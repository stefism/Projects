function townsToJson(data) {
    const isNotEmptyString = x => x !== ""
    const trimMyString = x => x.trim()
    const parseIfNumber = x => Number(x) ? Math.floor(Number(x) * 100) / 100 : x

    let keys = deserializeStringToArrayOfValues(data[0])

    return data
        .slice(1)
        .map(deserializeStringToArrayOfValues)
        .map(x => x.reduce((res, val, i) => {
            res[keys[i]] = val
            return res
    }, {}))

    function deserializeStringToArrayOfValues(str) {
        return str
            .split("|")
            .filter(isNotEmptyString)
            .map(trimMyString)
            .map(parseIfNumber)
    }
}

console.log(townsToJson([
        '| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |'
    ]
))