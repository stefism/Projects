function addItem() {
    let text = document.getElementById('newItemText');
    let value = document.getElementById('newItemValue');
    let menu = document.getElementById('menu');

    let option = document.createElement('option');
    option.value = value.value;
    option.textContent = text.value;

    menu.appendChild(option);
    
    value.value = '';
    text.value = '';
}