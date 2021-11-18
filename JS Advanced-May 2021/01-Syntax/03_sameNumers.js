function sameNumbers(number){
    let numbersAsString = number.toString().split("");

    let totalSum = 0;
    let isSame = checkForSameNumbers(numbersAsString);

    numbersAsString.forEach(element => {
        currentNumber = parseInt(element);
        totalSum += currentNumber;
    });

    function checkForSameNumbers(numbers) {
        let firstNumber = numbers[0];

        for (let i = 1; i < numbers.length; i++) {
            if (firstNumber === numbers[i]) {
                continue;
            }

            return false;
        }

        return true;
    }

    console.log(isSame);
    console.log(totalSum);
}

sameNumbers(2222222);