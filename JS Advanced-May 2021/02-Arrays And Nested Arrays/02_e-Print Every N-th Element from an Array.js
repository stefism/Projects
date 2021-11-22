function solve(array, element){
    let result = [];
    for (let i = 0; i < array.length; i += element) {
        
        result.push(array[i]);
    }

    return result;
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2));

function solve2(array, step){
    return array.filter((element, index) => index % step === 0);
}

console.log(solve2(['5', 
'20', 
'31', 
'4', 
'20'], 
2));