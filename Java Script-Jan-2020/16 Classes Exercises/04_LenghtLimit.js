class Stringer{
    constructor(innerString, innerLength) {
        this.innerString = innerString
        this.innerLength = +innerLength
        this.initialLength = +innerLength
    }

    decrease(newLength){
        this.innerLength = this.initialLength - newLength

        if(this.innerLength < 0){
            this.innerLength = 0
        }

        return this.innerLength
    }

    increase(newLength){
        this.innerLength = newLength + this.initialLength

        return this.innerLength
    }

    toString(){
        if(this.innerString.length <= this.innerLength){
            return this.innerString
        } else {
            let subStr = this.innerString.substring(0, this.innerLength)
            return `${subStr}...`
        }
    }
}

let test = new Stringer("Test", 5)
console.log(test.toString())

test.decrease(3)
console.log(test.toString())

test.decrease(5)
console.log(test.toString())

test.increase(4)
console.log(test.toString())