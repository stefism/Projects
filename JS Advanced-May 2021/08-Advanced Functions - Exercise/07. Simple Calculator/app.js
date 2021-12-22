function calculator() {
    let selector1;
    let selector2;
    let resultSelector;

    function initialize(s1, s2, resultSel) {
        selector1 = document.querySelector(s1);
        selector2 = document.querySelector(s2);
        resultSelector = document.querySelector(resultSel);
    }

    function add() {  
        resultSelector.value = Number(selector1.value) + Number(selector2.value);
    }

    function subtract() {
        resultSelector.value = Number(selector1.value) - Number(selector2.value);
    }

    return {
        init: initialize,
        add,
        subtract
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');