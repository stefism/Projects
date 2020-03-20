function countWords(text) {
    let string = text[0].match(/\w+/gim)
    let obj = {}

    for (let i = 0; i < string.length; i++) {
        if(typeof obj[string[i]] === "undefined"){
            obj[string[i]] = 0
        }
        obj[string[i]]++
    }

    let json = JSON.stringify(obj)

    return json
}

console.log(countWords(["Far too slow, you're far too slow."]))