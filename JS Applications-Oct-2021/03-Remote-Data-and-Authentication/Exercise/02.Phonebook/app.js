let loadBtn = document.getElementById('btnLoad');
loadBtn.addEventListener('click', loadContacts);

let createBtn = document.getElementById('btnCreate');
createBtn.addEventListener('click', createContact);

let contactsUlElement = document.getElementById('phonebook');
contactsUlElement.addEventListener('click', removeContact);

let personNameElement = document.getElementById('person');
let personPhoneElement = document.getElementById('phone');

//Всички html елементи имат едно свойство, което се нарича dataset. Когато добавим на елемента атрибут, който започва със data-{нещо си}, името след тирето се записва в този dataset и след това може да бъде ползвано. Ако напишем в конзолата {името на html елемента}.dataset ще видим всички атрибути, които започват с data. Ползва се когато имаме нужда да запазим някакви си наши данни извън стандартно дефинираните. След това го ползваме като {името на html елемента}.dataset.{името след тирето в което сме запазили данните}.

let url = 'http://localhost:3030/jsonstore/phonebook/';

async function loadContacts() {
    contactsUlElement.replaceChildren();

    try {
        let responce = await fetch(url);
        let result = await responce.json();

        Object.values(result).forEach(createLiElementForContact);
    } catch (error) {

    }
}

function createLiElementForContact(contact) {
    let liContact = document.createElement('li');
    liContact.textContent = `${contact.person}: ${contact.phone} `;
    liContact.id = contact._id;

    let deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';

    liContact.appendChild(deleteBtn);

    contactsUlElement.appendChild(liContact);
}

async function createContact() {
    let person = personNameElement.value;
    let phone = personPhoneElement.value;

    try {
        let responce = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ person, phone })
        });

        let result = await responce.json();

        personNameElement.value = '';
        personPhoneElement.value = '';

        createLiElementForContact(result);
    } catch (error) {

    }
}

async function removeContact(e) {
    if (e.target.tagName != 'BUTTON') {
        return;
    }

    let contactKey = e.target.parentNode.id;
    let delUrl = url + contactKey;

    try {
        let responce = await fetch(delUrl, {
            method: 'delete'
        });

        await responce.json();

        e.target.parentNode.remove();
    } catch (error) {

    }
}