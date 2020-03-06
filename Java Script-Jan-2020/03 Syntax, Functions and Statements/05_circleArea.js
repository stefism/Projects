function calcCircleArea(input){
let inputType = typeof(input);

    if (inputType === 'number') {
        console.log((Math.pow(input, 2) * Math.PI).toFixed(2));
    } 
    else {
        console.log('We can not calculate the circle area, because we receive a ' + inputType + '.');
    }
}

calcCircleArea();