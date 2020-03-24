function jsonsTable(input) {
    let inputObj = input.map(JSON.parse)

    let output = '<table>' + '\n'

    inputObj.map(x => extractObjtoTalbe(x))

    output += '</table>'

    return output

    function extractObjtoTalbe(object) {
        output += ` <tr>` + '\n'

        for(let key in object){
            output += `     <td>${object[key]}</td>` + '\n'
        }

        output += ` </tr>` + '\n'
    }
}

console.log(jsonsTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']
))