function greatestCommonDivisor(number1, number2){
    let lowestNumber = Math.min(number1, number2);
    let greatNumber = Math.max(number1, number2);

    let rest = greatNumber % lowestNumber;
    let gcd;

    if (rest !== 0) {
        while (gcd !== 0) {
            gcd = lowestNumber % rest
            greatNumber = lowestNumber
            lowestNumber = rest
     
            if (gcd !== 0) {
             rest = gcd
            }     
         }
         
         console.log(rest);

    } else {
        console.log(lowestNumber);
    }    
}

greatestCommonDivisor(42, 56)
