function solve() {
    let selectMenuTo = document.getElementById('selectMenuTo')
    let options = selectMenuTo.getElementsByTagName('option')[0]
    let hexadecimal = document.createElement('option')
    options.innerText = 'Binary'
    hexadecimal.innerText = 'Hexadecimal'
    selectMenuTo.appendChild(hexadecimal)
    options.value = 'binary'
    hexadecimal.value = 'hexadecimal'

    let button = document.getElementsByTagName('button')[0]
    button.addEventListener('click', applyConvert)

    let inputNumber = document.getElementById('container')
        .children[1]
    //debugger
    let resultElement = document.getElementById('result')

    function applyConvert() {
        let result
        //debugger
        if(selectMenuTo.selectedIndex === 0){
            result = converter(inputNumber.value, 'B')
            //debugger
        } else if(selectMenuTo.selectedIndex === 1){
            result = converter(inputNumber.value, 'H')
        }
        //debugger
        resultElement.value = result.toUpperCase()
        //debugger
    }

    function converter(n, base) {
        if (n < 0) {
            n = 0xFFFFFFFF + n + 1;
        }
        switch (base) {
            case 'B':
                return parseInt(n, 10).toString(2);
                break;
            case 'H':
                return parseInt(n, 10).toString(16);
                break;
            case 'O':
                return parseInt(n, 10).toString(8);
                break;
            default:
                return ("Wrong input.........");
        }
    }
}