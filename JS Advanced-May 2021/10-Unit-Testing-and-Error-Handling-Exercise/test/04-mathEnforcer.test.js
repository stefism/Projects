let mathEnforcer = require('../04-mathEnforcer');
let assert = require('chai').assert;

describe('Test mathEnforcer object', () => {
    it('Test addFive() to return undefined if input is not a number', () => {
        assert.equal(mathEnforcer.addFive('Pesho'), undefined);
    });

    it('Test addFive() to return correct sum in input is correct', () => {
        assert.equal(mathEnforcer.addFive(5), 10);
        assert.equal(mathEnforcer.addFive(2,5), 7,5);
    });

    it('Test subtractTen() to return undefined if input is not a number', () => {
        assert.equal(mathEnforcer.subtractTen('Pesho'), undefined);
    });

    it('Test subtractTen() to return correct sum in input is correct', () => {
        assert.equal(mathEnforcer.subtractTen(20), 10);
    });

    it('Test sum() to return undefined if inputs is not a number', () => {
        assert.equal(mathEnforcer.sum('Pesho', 'Gosho'), undefined);
        assert.equal(mathEnforcer.sum('Pesho', 2), undefined);
        assert.equal(mathEnforcer.sum(2, 'Gosho'), undefined);
    });

    it('Test sum() to return correct sum in inputs is correct', () => {
        assert.equal(mathEnforcer.sum(2, 2), 4);
        assert.equal(mathEnforcer.sum(5, 3), 8);
    });
});