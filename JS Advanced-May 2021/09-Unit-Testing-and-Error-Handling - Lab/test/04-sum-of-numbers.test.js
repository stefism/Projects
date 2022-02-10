//Конфигуриране на тестовете:
// 1. npm init - y
// 2. npm i mocha chai
// 3. In package.json -> "test": "mocha"
// 4. Make folder test and put test file in folder.
// 5. Write 'npm test' in terminal.

const assert = require('chai').assert;
const sum = require('../04-sum-of-numbers');

describe('Test sum functionality:', () => { //desccribe - групира тестовете по функционалност.
    it('Add positive numbers', () => {
        //Arrange
        let input = [1, 2, 3, 4, 5];
        let expectedResult = 15;
    
        //Act
        let actualResult = sum(input);
    
        //Assert
        assert.strictEqual(actualResult, expectedResult);
    });
    
    it('Not equal', () => {
        //Arrange
        let input = [20, 40, 60];
        let expectedResult = 15;
    
        //Act
        let actualResult = sum(input);
    
        //Assert
        assert.notEqual(actualResult, expectedResult);
    });
});