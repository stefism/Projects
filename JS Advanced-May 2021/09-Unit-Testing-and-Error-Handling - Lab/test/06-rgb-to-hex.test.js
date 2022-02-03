let rgbToHexColor = require('../06-rgb-to-hex');
let assert = require('chai').assert;

describe('Test Rgb to Hex', () => {
    it('Test to return correct Hex color if input is correct', () => {
        let expectedResult = '#FFFFFF';
        let actualResult = rgbToHexColor(255, 255, 255);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Return undefine if Red value is invalid', () => {
        let expectedResult = undefined;

        assert.strictEqual(rgbToHexColor(300, 255, 255), expectedResult);
        assert.strictEqual(rgbToHexColor(-1, 255, 255), expectedResult);
        assert.strictEqual(rgbToHexColor('edno', 255, 255), expectedResult);
    });

    it('Return undefine if Green value is invalid', () => {
        let expectedResult = undefined;

        assert.strictEqual(rgbToHexColor(255, 300, 255), expectedResult);
        assert.strictEqual(rgbToHexColor(255, -1, 255), expectedResult);
        assert.strictEqual(rgbToHexColor(255, 'edno', 255), expectedResult);
    });

    it('Return undefine if Blue value is invalid', () => {
        let expectedResult = undefined;

        assert.strictEqual(rgbToHexColor(255, 255, 300), expectedResult);
        assert.strictEqual(rgbToHexColor(255, 255, -1), expectedResult);
        assert.strictEqual(rgbToHexColor(255, 255, 'edno'), expectedResult);
    });
});