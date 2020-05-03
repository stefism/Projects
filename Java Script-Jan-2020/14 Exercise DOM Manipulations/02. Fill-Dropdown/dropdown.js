function addItem() {
    let newItemText = document.getElementById('newItemText')
    let newItemValue = document.getElementById('newItemValue')
    let menu = document.getElementById('menu')

    let option = document.createElement('option')
    option.innerText = newItemText.value
    option.value = newItemValue.value

    menu.appendChild(option)

    newItemText.value = ''
    newItemValue.value = ''
}