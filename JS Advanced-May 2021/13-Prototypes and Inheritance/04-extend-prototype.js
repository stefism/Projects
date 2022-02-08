function extendProrotype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function() {
        return `I am a ${this.species}. ${classToExtend}`;
    }
}

class Test {
    constructor(name) {
        this.name = name;
    }
}

extendProrotype(Test);

let test = new Test('Pesho');
console.log(test.toSpeciesString());