function evenPositionElement(array) {
    let result = '';

    let evenNumber = array.filter((item, index, source) => {
        if(index % 2 === 0){
           result += item + ' '
        }
    })

    console.log(result)
}

evenPositionElement(['20', '30', '40'])