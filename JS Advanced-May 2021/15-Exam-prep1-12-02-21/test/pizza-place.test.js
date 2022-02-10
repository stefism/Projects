const assert = require('chai').assert;
const pizzUni = require('../03/pizza-place');

describe("Pizz uni tests", function() {
    describe("Test function makeAnOrder(obj)", function() {
        it("Test make pizza properly", function() {
            let pizza = {orderedPizza: 2, orderedDrink: 3};
            let result = pizzUni.makeAnOrder(pizza);

            assert.equal(result, 'You just ordered 2 and 3.');
        });

        it("Test throw error if pizza obj not contains property orderedPizza", function() {
            let pizza = {orderedDrink: 3};
            // assert.throw(() => { pizzUni.makeAnOrder(pizza) }, 'You must order at least 1 Pizza to finish the order.');
            assert.throw(pizzUni.makeAnOrder.bind(null, pizza), 'You must order at least 1 Pizza to finish the order.'); //Алтернатива на ароу функцията - с байнд.
        });
     });

     describe("Test function getRemainingWork(statusArr)", function() {
        it("Test preparing message", function() {
            let pizzasStatus = [{pizzaName: 'Edno', status: 'ready'}, {pizzaName: 'Dve', status: 'preparing'}, {pizzaName: 'Tri', status: 'preparing'}];
            
            let result = pizzUni.getRemainingWork(pizzasStatus);

            assert.equal(result, 'The following pizzas are still preparing: Dve, Tri.');
        });

        it("Test if all orders are complete", function() {
            let pizzasStatus = [{pizzaName: 'Edno', status: 'ready'}, {pizzaName: 'Dve', status: 'ready'}, {pizzaName: 'Tri', status: 'ready'}];
            
            let result = pizzUni.getRemainingWork(pizzasStatus);

            assert.equal(result, 'All orders are complete!');
        });
     });

     describe("Test function orderType(totalSum, typeOfOrder)", function() {
        it("Test Carry Out", function() {
            let result = pizzUni.orderType(100, 'Carry Out');
            assert.equal(result, 90);
        });

        it("Test Delivery", function() {
            let result = pizzUni.orderType(100, 'Delivery');
            assert.equal(result, 100);
        });
     });
});
