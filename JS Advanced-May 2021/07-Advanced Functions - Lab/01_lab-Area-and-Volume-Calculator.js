function area() {
    return Math.abs(this.x * this.y);
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

function solve (areaF, volF, input) {
    let jsonInput = JSON.parse(input);
    let output = [];

    jsonInput.forEach(input => {
        let area = areaF.call(input);
        let volume = volF.call(input);

        let currOutput = { area, volume };
        output.push(currOutput);
    });

    return output;
}

solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`);