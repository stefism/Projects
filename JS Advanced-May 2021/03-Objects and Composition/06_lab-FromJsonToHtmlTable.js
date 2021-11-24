function fromJsomTpHtmlTable(input){
    let result = `<table>\n`;

    let headers = input[0];
    result += '<tr>'
    
    for(let header in headers){
        result += `<th>${header.trim()}</th>`;
    }

    result += '</tr>\n'
    
    input.forEach(elements => {
        result += '<tr>'

        for(element in elements){
            result += `<td>${elements[element]}</td>`
        }

        result += '</tr>\n'
    });

    result += '</table>'

    return result;
}

fromJsomTpHtmlTable([{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]);