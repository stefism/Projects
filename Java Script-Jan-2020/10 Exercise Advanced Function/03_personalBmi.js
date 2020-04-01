function personalBmi(name, age, weight, height) {
    let bmi = Math.round(weight / Math.pow(height / 100, 2))

    let stat = function(bmi){
        if(bmi < 18.5){
            return 'underweight'
        } else if (bmi < 25){
            return 'normal'
        } else if(bmi < 30){
            return 'overweight'
        } else {
            return 'obese'
        }
    }

    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: bmi,
        status: stat(bmi)
    }

    if(person.status === 'obese'){
        person.recommendation = 'admission required'
    }

    return person
}

console.log(personalBmi('Peter', 29, 75, 182))