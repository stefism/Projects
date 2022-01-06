let evenOrOdd = require('../02-even-or-odd');
let assert = require('chai').assert;

describe('Test Even or Odd.', () => {
    it('Test if input != string whether he will return undefined.', () => {
        assert.strictEqual(evenOrOdd(12), undefined);
        assert.strictEqual(evenOrOdd(true), undefined);
    });

    it('Return Odd in string.lenght is Odd number', () => {
        assert.strictEqual(evenOrOdd('Odd'), 'odd');
    });

    it('Return Even in string.lenght is Even number', () => {
        assert.strictEqual(evenOrOdd('Even'), 'even');
    });
});