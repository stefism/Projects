function solve(array){
    let result = array.reduce((acc, curr) => {
        let lastElement = acc[acc.length - 1];
        
        if (lastElement == undefined || lastElement < curr) {
            acc.push(curr);
        }

        return acc;
    }, []);

    return result;
}

console.log(solve([20, 
    3, 
    2, 
    15,
    6, 
    1]));