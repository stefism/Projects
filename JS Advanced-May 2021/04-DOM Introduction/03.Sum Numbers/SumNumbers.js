function calc() {
    let num1 = document.getElementById('num1').value;
    let num2 = document.getElementById('num2').value;
    let sum = document.getElementById('sum');

    let result = Number(num1) + Number(num2);
    sum.value = result;
}
