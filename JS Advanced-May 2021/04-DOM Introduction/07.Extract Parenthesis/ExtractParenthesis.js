function extract(content) {
    let text = document.getElementById(content).textContent;
    console.log(text);

    let result = [];
    
    while(true){
        let searchStart = text.indexOf('(');
        let searchEnd = text.indexOf(')');

        if (searchStart == -1) {
            break;
        }

        let word = text.slice(searchStart, searchEnd  + 1);
        text = text.substring(0, searchStart) + text.substring(searchEnd + 1)
        result.push(word);
    }

    for(const r in result){
        result[r] = result[r].substring(1);
        result[r] = result[r].substring(0, result[r].length - 1);
    }

    let el = document.getElementById(content);
    return result.join(" ");
}