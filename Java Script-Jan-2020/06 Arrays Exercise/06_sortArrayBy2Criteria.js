function sortArray(array) {
    array.sort((a, b) => {
        if(a.length < b.length){
            return -1
        }
        else if(a.length > b.length){
            return  1
        }
        else {
            if(a < b){
                return  -1
            }
            else if(a > b){
                return 1
            }
            else{
                return 0
            }
        }
    })

    return array.join('\n')
}

console.log(sortArray(['test',
    'Deny',
    'omen',
    'Default']
))