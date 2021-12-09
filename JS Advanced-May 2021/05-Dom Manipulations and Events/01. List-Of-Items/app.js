let firstItems = document.querySelectorAll('#items li a');
firstItems.forEach(item => {
    item.addEventListener('click', deleteItem);
});

function addItem() {
    let items = document.getElementById('items');
    let input = document.getElementById('newItemText');

    let li = document.createElement('li');
    li.textContent = input.value;

    let deleteLink = document.createElement('a');
    deleteLink.setAttribute('href', '#');
    deleteLink.textContent = '[Delete]';

    deleteLink.addEventListener('click', deleteItem);

    li.appendChild(deleteLink);

    items.appendChild(li);
    input.value = '';
}

function deleteItem(e) {
    e.preventDefault();
    e.currentTarget.parentNode.remove();
}