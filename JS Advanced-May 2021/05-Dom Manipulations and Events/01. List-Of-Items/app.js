function addItem() {
    let input = document.getElementById('newItemText');
    let items = document.getElementById('items');

    let li = document.createElement('li');
    li.textContent = input.value;

    items.appendChild(li);
    input.value = '';
}