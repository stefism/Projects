function juiceFlavours(inputArray) {
    let bottles = {};

    inputArray.forEach(juice => {
        let [name, quantity] = juice.split(' => ');
        
        if(!bottles[name]) {
            bottles[name] = 0;
        }

        bottles[name] += quantity;
    })
}