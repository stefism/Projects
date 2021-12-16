function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve (areaF, volF, input) {
    let jsonInput = JSON.parse(input);
    let output = [];

    jsonInput.forEach(input => {
        console.log(input.x, input.y);
        let area = areaF(Number(input.x), Number(input.y));
        let vol = volF(Number(input.x), Number(input.y), Number(input.z));
        console.log(area, vol);
    });
}

solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`);