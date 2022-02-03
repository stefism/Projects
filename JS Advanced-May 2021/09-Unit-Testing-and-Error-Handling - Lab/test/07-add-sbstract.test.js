let createCalculator = require('../07-add-substract');
let assert = require('chai').assert;

describe('Test calculator', () => {
    it('Return value for add', () => {
        let calc = createCalculator();
        calc.add(5);
        
        assert.strictEqual(calc.get(), 5);

        calc.add(5);

        assert.strictEqual(calc.get(), 10);
    });

    it('Return value for subtract', () => {
        let calc = createCalculator();
        calc.add(5);
        calc.subtract(3);
        
        assert.strictEqual(calc.get(), 2);
    });
});