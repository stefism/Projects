class Hex { // 80/100
    constructor(value) {
        this.value = value;
    }

    toString = () => '0x' + this.value.toString(16).toUpperCase();
    valueOf = () => this.value; // Също е дефолтен метод, който се презаписва в този случай.
    parse = (number) => parseInt(number, 16);
    plus = (number) => typeof(number) == 'object' ? new Hex(this.value + number.value) : new Hex(this.value + number);
    minus = (number) => typeof(number) == 'object' ? new Hex(this.value - number.value) : new Hex(this.value - number);
}

class Hex2 { // 100/100
    constructor(value) {
        this.value = value;
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }

    valueOf() {
        return this.value;
    }

    plus(number) {
        if(typeof(number) == 'object') {
            let result = this.value + number.value;
            return new Hex(result);
        } else {
            let result = this.value + number;
            return new Hex(result);
        }
    }

    minus(number) {
        if(typeof(number) == 'object') {
            let result = this.value - number.value;
            return new Hex(result);
        } else {
            let result = this.value - number;
            return new Hex(result);
        }
    }

    parse(number) {
        return parseInt(number, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));