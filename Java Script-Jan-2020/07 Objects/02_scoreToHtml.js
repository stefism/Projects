function scoreToHtml(input) {
    let obj = JSON.parse(input)

    let output = "<table> \n"
    output += "  <tr><th>name</th><th>score</th></tr> \n"

    for(let i of obj){
        output += `  <tr><td>${i.name}</td><td>${i.score}</td></tr> \n`
    }
    output += "</table>"



    return escapeHtml(output)

    function escapeHtml(text) {
        return text
            .replace(/&/g, "&amp;")

    }
}

console.log(scoreToHtml(['[{"name":"Pesho & Kiro", "score":479}, {"name":"Gosho, Maria & Viki", "score":205}]']
))