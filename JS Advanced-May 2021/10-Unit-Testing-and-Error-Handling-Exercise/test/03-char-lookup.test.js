let lookupChar = require('../03-char-lookup');
let assert = require('chai').assert;

describe('Test lookupChar', () => {
    it('Return undefined if string) !== string || !Number.isInteger(index)', () => {
        assert.equal(lookupChar(true, 12), undefined);
        assert.equal(lookupChar(12, 5), undefined);
        assert.equal(lookupChar([4, 3], 5), undefined);
        assert.equal(lookupChar('Ivan e gotin', 'Da'), undefined);
        assert.equal(lookupChar('Ivan e gotin', 12.3), undefined);
    });

    it('Return "Incorrect index" if index < 0', () => {
        assert.equal(lookupChar('Ivan e gotin', -1), 'Incorrect index');
        assert.equal(lookupChar('Ivan', 15), 'Incorrect index');
    });

    it('Return correct index if input parameters is valid', () => {
        assert.equal(lookupChar('Ivan e gotin', 3), 'n');
        assert.equal(lookupChar('Ivan e gotin', 0), 'I');
        
    });
});