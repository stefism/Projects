class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = Number(innerLength);
    }

    increase = (number) => this.innerLength += Number(number);

    decrease(number) {
        this.innerLength -= Number(number);
        this.innerLength < 0 ? this.innerLength = 0 : this.innerLength;
    }

    toString() {
        return this.innerString.length <= this.innerLength ? this.innerString : this.innerString.substring(0, this.innerLength) + '...';
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
