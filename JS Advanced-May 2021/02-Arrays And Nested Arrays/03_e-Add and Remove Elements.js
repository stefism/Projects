function solve(input){
    let result = [];
    let count = 1;

    input.forEach(element => {
        if (element == 'add') {
            result.push(count++);
        }
        else {
            result.pop();
            count++;
        }
    });

    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}

solve(['add', 
'add', 
'remove', 
'add', 
'add']);