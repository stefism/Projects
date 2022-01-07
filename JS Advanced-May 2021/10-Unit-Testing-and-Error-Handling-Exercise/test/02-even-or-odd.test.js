let evenOrOdd = require('../02-even-or-odd');
let assert = require('chai').assert;

describe('Test Even or Odd.', () => {
    it('Test if input != string whether he will return undefined.', () => {
        assert.isUndefined(evenOrOdd(12));
        assert.equal(evenOrOdd(true), undefined);
    });

    it('Return Odd in string.lenght is Odd number', () => {
        assert.equal(evenOrOdd('Odd'), 'odd');
    });

    it('Return Even in string.lenght is Even number', () => {
        assert.equal(evenOrOdd('Even'), 'even');
    });
});