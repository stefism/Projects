function solve(array, element){
    let result = [];
    for (let i = 0; i < array.length; i += element) {
        
        result.push(array[i]);
    }

    return result;
}

console.log(solve(['1', 
'2',
'3', 
'4', 
'5'], 
6));