function solve(array){
    array.sort((a, b) => { 
        if (a.length === b.length) {
            return a.localeCompare(b);  
        } else {
            return a.length - b.length;
        }
    });
    
    console.log(array.join("\n"));
}

solve(['alpha', 
'beta', 
'gamma']);