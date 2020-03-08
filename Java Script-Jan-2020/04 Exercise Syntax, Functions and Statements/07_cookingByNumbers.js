function cookingByNumbers(input) {
    let number = Number(input[0]);

    let result = number;
    
    for (let i = 1; i < input.length; i++) {
        
        switch (input[i]) {
            case 'chop':
                result = result / 2
                break;

            case 'dice':
                result = Math.sqrt(result)
                break;

            case 'spice':
                result = result + 1
                break;

            case 'bake':
                result = result * 3
                break;

            case 'fillet':
                result = result * 0.8
                break;
        }

        console.log(result);
    }
}

cookingByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);