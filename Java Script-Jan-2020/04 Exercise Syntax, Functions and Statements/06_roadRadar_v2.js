function roadRadar(input) {
    let limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    }

    let speed = input[0];
    let area = input[1];

    let calculateOverLimit = (limit, speed) => {
        if (limit >= speed) {
            console.log()
            return;
        }

        let overLimit = speed - limit;

        if (overLimit <= 20) {
            console.log('speeding')
        } else if (overLimit <= 40) {
            console.log('excessive speeding')
        } else if (overLimit > 40) {
            console.log('reckless driving')
        }
    }

    switch (area) {
        case 'city':
            calculateOverLimit(limits[area], speed)
            break;

        case 'residential':
            calculateOverLimit(limits[area], speed)
            break;

        case 'interstate':
            calculateOverLimit(limits[area], speed)
            break;

        case 'motorway':
            calculateOverLimit(limits[area], speed)
            break;
    }
}

roadRadar([21, 'residential'])
