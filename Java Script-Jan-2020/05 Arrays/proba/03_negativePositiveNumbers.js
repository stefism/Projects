function rearrangeNumbers(array) {
    for (let i = 0; i < array.length; i++) {
        if(array[i] < 0){
            let negativeNumber = Number(array.splice(i, 1))
            array.unshift(negativeNumber)
        }
    }

    array.forEach(x => console.log(x))
}

rearrangeNumbers([3, -2, 0, -1])