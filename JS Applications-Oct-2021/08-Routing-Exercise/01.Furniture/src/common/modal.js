const element = document.createElement('div');

element.id = 'overlay';
element.innerHTML = `
<div id="modal">
    <p>Are you sure?</p>
    <div>
        <button class="modal-ok">OK</button>
        <button class="modal-cancel">Cancel</button>
    </div>
</div>
`;

element.querySelector('.modal-ok').addEventListener('click', () => onChoice(true));
element.querySelector('.modal-cancel').addEventListener('click', () => onChoice(false));

const msg = element.querySelector('p');
let currentCallback = null;

export function showModal(message, callback) {
    currentCallback = callback;

    msg.textContent = message;
    document.body.appendChild(element);
}

function onChoice(choice) {
    clearModal();
    currentCallback(choice);
}

export function clearModal() {
    element.remove();
}