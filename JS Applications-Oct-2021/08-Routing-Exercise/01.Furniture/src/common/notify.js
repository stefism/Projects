const element = document.createElement('div');
element.id = 'notification';

const msg = document.createElement('span');
const closeBtn = document.createElement('span');

closeBtn.innerHTML = '&#10006';
element.appendChild(msg);
element.appendChild(closeBtn);

element.addEventListener('click', clearNotify);

export function notify(message) {
    msg.textContent = message;
    document.body.appendChild(element);

    setTimeout(clearNotify, 3000); //Изчезва само след 3 секунди.
}

export function clearNotify() {
    element.remove();
}