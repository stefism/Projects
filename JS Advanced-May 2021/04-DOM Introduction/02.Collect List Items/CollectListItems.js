function extractText2() {
    let listItems = document.getElementById('items').textContent;
    let result = document.getElementById('result');
    result.textContent = listItems.trim();
}

function extractText() {
    let listItems = document.querySelectorAll('#items li');
    let result = '';

    for(const item of listItems){
        result += item.textContent.trim() + '\n';
    }

    let resultElement = document.getElementById('result');
    resultElement.textContent = result.trim();
}