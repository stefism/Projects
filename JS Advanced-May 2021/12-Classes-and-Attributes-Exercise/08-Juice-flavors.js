function juiceFlavours(inputArray) {
    let bottles = {};
    let output = {};

    inputArray.forEach(juice => {
        let [name, quantity] = juice.split(' => ');
        
        if(!bottles[name]) {
            bottles[name] = 0;
        }

        bottles[name] += Number(quantity);

        if(bottles[name] >= 1000) {
            let bottlesNumber = bottles[name] / 1000;
            let [bottlesMake, remainder] = bottlesNumber.toString().split('.');

            if(!output[name]) {
                output[name] = Number(bottlesMake);
            } else {
                output[name] += Number(bottlesMake);
            }
            
            bottles[name] = Number(remainder);
        }
    });

    for(const fruit in output) {
        console.log(`${fruit} => ${output[fruit]}`);
    }
}

juiceFlavours(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549',
'Orange => 1020']
);