function calorieObject(objects){
    let result = '{ ';

    for (let i = 0; i < objects.length - 1; i++) {
        
        if (i === objects.length - 2) {
            result += `${objects[i]}: ${objects[i + 1]} ` 

        } else {
            result += `${objects[i]}: ${objects[i + 1]}, `
        }
        
        i+= 1
    }

    result += '}';

    console.log(result);
}

calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);