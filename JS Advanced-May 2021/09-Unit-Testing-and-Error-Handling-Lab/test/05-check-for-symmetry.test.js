let isSymmetric = require('../05-check-for-symmetry');
let assert = require('chai').assert;

describe('Test symmetric functionality', () => {
    it('Test if input is not array', () => {
        let expectedResult = false;
        let actualResult = isSymmetric('Krasimir');

        assert.strictEqual(actualResult, expectedResult);
        assert.strictEqual(isSymmetric(0), expectedResult);
        assert.strictEqual(isSymmetric(false), expectedResult);
        assert.strictEqual(isSymmetric({}), expectedResult);
        assert.strictEqual(isSymmetric(undefined), expectedResult);
    });

    it('Return true if the input array is symmetric', () => {
        let expectedResult = true;
        let actualResult = isSymmetric([1, 2, 1]);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Return false if the input array contains different types', () => {
        let expectedResult = false;
        let actualResult = isSymmetric(['1', 2, 1]);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Return true if the input array is symmetric 2', () => {
        let expectedResult = true;
        let actualResult = isSymmetric([1, 1, 1]);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Return true if the input array is symmetric 3', () => {
        let expectedResult = true;
        let actualResult = isSymmetric([10, 1, 1, 10]);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Return false if the input array is not symmetric', () => {
        let expectedResult = false;
        let actualResult = isSymmetric([1, 2, 5]);

        assert.strictEqual(actualResult, expectedResult);
    });
});