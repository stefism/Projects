function toggle() {
    let btnElement = document.getElementsByClassName('button')[0];
    let textElement = document.getElementById('extra');

    if (textElement.style.display == 'none') {
        textElement.style.display = 'block';
        btnElement.textContent = 'Less';
    }
    else {
        textElement.style.display = 'none';
        btnElement.textContent = 'More';
    }
}