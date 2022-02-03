const assert = require('chai').assert;
const payment = require('../12-Payment-package');

describe("Payment Package Tests", function() {
    let instance = undefined;

    beforeEach(() => {
        instance = new payment('HR Services', 1500);
    }); // Преди всеки тест ще прави инстанция на това нещо.

    it("Check default values", function() {
        assert.equal(instance._name, 'HR Services', 'Check ._name');
        assert.equal(instance._value, 1500, 'Check ._value');
        assert.equal(instance._VAT, 20, 'Check ._VAT');
        assert.equal(instance._active, true, 'Check ._active');

        assert.equal(instance.name, 'HR Services', 'Check .name');
        assert.equal(instance.value, 1500, 'Check .value');
        assert.equal(instance.VAT, 20, 'Check .VAT');
        assert.equal(instance.active, true, 'Check .active');
    });
    
    it("Check properly change .name and throw error if name is incorect", function() {
        instance.name = 'Pesho';

        assert.equal(instance.name, 'Pesho', 'Check change name');
        assert.throw(() => {instance.name = ''}, 'Name must be a non-empty string', 'Check throw Error if name = empty string');
        assert.throw(() => {instance.name = 2}, 'Name must be a non-empty string', 'Check throw Error if name = 2');
        assert.throw(() => {instance.name = undefined}, 'Name must be a non-empty string', 'Check throw Error if name = undefined');
    });

    it("Check properly change .VAT and throw error if .VAT is incorect", function() {
        instance.VAT = 40;

        assert.equal(instance.VAT, 40, 'Check change .VAT');
        assert.throw(() => {instance.VAT = ''}, 'VAT must be a non-negative number', 'Check throw Error if VAT = empty string');
        assert.throw(() => {instance.VAT = -2}, 'VAT must be a non-negative number', 'Check throw Error if VAT = -2');
    });
});
