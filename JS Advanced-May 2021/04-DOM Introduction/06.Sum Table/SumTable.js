function sumTable2() {
    let sumsElements = document.getElementsByTagName('tbody')[0];
    let elements = sumsElements.querySelectorAll('td:nth-of-type(2n)');

    let sum = 0;

    for (let i = 0; i < elements.length - 1; i++) {
        sum += Number(elements[i].textContent);
    }

    let sumElement = document.getElementById('sum');
    sumElement.textContent = sum;
}

function sumTable(){
    let costTdElements = Array.from(document.querySelectorAll('td:nth-child(2)'));
    let sumElement = costTdElements.pop();
    let sum = costTdElements.reduce((a, x) => a + Number(x.textContent), 0);

    sumElement.textContent = sum;
}