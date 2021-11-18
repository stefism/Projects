function circleArea(input) {
    if (typeof input != "number") {
        console.log(`We can not calculate the circle area, because we receive a ${typeof input}.`);
    }
    else {
        let radius = Math.PI * Math.pow(input, 2);
        console.log(radius.toFixed(2));
    }
}

circleArea(5);
