function addItem() {
    let list = document.getElementById('items')
    let newItemText = document.getElementById('newItemText')
    let newItem = document.createElement('li')
    newItem.innerText = newItemText.value
    list.appendChild(newItem)
    newItemText.value = ''
    console.log('TODO:...');
}