function roadRadar(input) {
    let motorwaySpeedLimit = 130;
    let interstateSpeedLimit = 90;
    let citySpeedLimit = 50;
    let residentalSpeedLimit = 20;

    let speed = input[0];
    let area = input[1];

    let result;

    switch (area) {
        case 'city':
            if (speed <= citySpeedLimit) {
                result = '';
            }
            else if (speed > citySpeedLimit && speed <= citySpeedLimit + 20) {
                result = 'speeding';
            }
            else if (speed > citySpeedLimit + 20 && speed <= citySpeedLimit + 40) {
                result = 'excessive speeding';
            }
            else if (speed > citySpeedLimit + 40) {
                result = 'reckless driving';
            }
            break;

        case 'motorway':
            if (speed <= motorwaySpeedLimit) {
                result = '';
            }
            else if (speed > motorwaySpeedLimit && speed <= motorwaySpeedLimit + 20) {
                result = 'speeding';
            }
            else if (speed > motorwaySpeedLimit + 20 && speed <= motorwaySpeedLimit + 40) {
                result = 'excessive speeding';
            }
            else if (speed > motorwaySpeedLimit + 40) {
                result = 'reckless driving';
            }
            break;

            case 'interstate':
                if (speed <= interstateSpeedLimit) {
                    result = '';
                }
                else if (speed > interstateSpeedLimit && speed <= interstateSpeedLimit + 20) {
                    result = 'speeding';
                }
                else if (speed > interstateSpeedLimit + 20 && speed <= interstateSpeedLimit + 40) {
                    result = 'excessive speeding';
                }
                else if (speed > interstateSpeedLimit + 40) {
                    result = 'reckless driving';
                }
                break;

                case 'residential':
                    if (speed <= residentalSpeedLimit) {
                        result = '';
                    }
                    else if (speed > residentalSpeedLimit && speed <= residentalSpeedLimit + 20) {
                        result = 'speeding';
                    }
                    else if (speed > residentalSpeedLimit + 20 && speed <= residentalSpeedLimit + 40) {
                        result = 'excessive speeding';
                    }
                    else if (speed > residentalSpeedLimit + 40) {
                        result = 'reckless driving';
                    }
                    break;
    }

    console.log(result);
}

roadRadar([40, 'city']);