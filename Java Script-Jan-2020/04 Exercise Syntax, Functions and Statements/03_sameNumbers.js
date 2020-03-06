function sameNumbers(number){
    let numberAsString = String(number);
    let isFalse = false;
    let sum = 0;

    for (let i = 0; i < numberAsString.length - 1; i++) {
        
        if (numberAsString[i] !== numberAsString[i + 1]) {           
            isFalse = true                      
        }
        
        sum += Number(numberAsString[i]);
    }

    sum += Number(numberAsString[numberAsString.length - 1]);

    if (isFalse == false) {
        console.log('true')

    } else {
        console.log('false')
    }

    console.log(sum)
}

sameNumbers(1234);