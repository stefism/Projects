function validityChecker([x1, y1, x2, y2]) {
    let x1Y1To00 = (x1 ** 2) + (y1 ** 2)
    x1Y1To00 = String(Math.sqrt(x1Y1To00))

    let isInteger = x1Y1To00.includes('.');

    console.log(`{${x1}, ${y1}} to {0, 0} is ${isInteger ? 'invalid' : 'valid'}`);

    let x2Y2To00 = (x2 ** 2) + (y2 ** 2)
    x2Y2To00 = String(Math.sqrt(x2Y2To00))

    isInteger = x2Y2To00.includes('.');

    console.log(`{${x2}, ${y2}} to {0, 0} is ${isInteger ? 'invalid' : 'valid'}`);

    let a = Math.abs(x1 - x2)
    let b = Math.abs(y1 - y2)

    let c = (a ** 2) + (b ** 2)
    c = String(Math.sqrt(c))

    isInteger = c.includes('.')

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isInteger ? 'invalid' : 'valid'}`);
}

validityChecker([3, 0, 0, 4])