function greatestCommonDivisor(numberOne, numberTwo){
    let largestNumber = Math.max(numberOne, numberTwo);
    let lowestNumber = Math.min(numberOne, numberTwo);

    let gcd;
    let divided = largestNumber; //делимо
    let divisor = lowestNumber; // делител

    while (true) {
        let result = divided % divisor; // divided=84 / divisor=18

        if (result == 0) {
            gcd = divisor;
            break;
        }

        divided = divisor;
        divisor = result;
    }

    console.log(gcd);
}

greatestCommonDivisor(2154, 458);