function rotateArray(array, rotation){
    for (let i = 0; i < rotation; i++) {
        let number = array.pop();
        array.unshift(number);
    }

    let result = array.join(' ');
    console.log(result);
}

rotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15);