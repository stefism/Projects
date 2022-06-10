const container = document.createElement('div');
container.id = 'notification';

const list = document.createElement('ul');
list.addEventListener('click', closeListItem)
container.appendChild(list);

document.body.appendChild(container);

export function notify(message) {
    const listItem = document.createElement('li');
    listItem.className = 'notification';
    listItem.textContent = message + '  \u2716';

    list.appendChild(listItem);

    setTimeout(() => listItem.remove(), 3000);
}

function closeListItem(e) {
    if(e.target.tagName == 'LI') {
        e.target.remove();
    }
}