let loadBtn = document.getElementById('btnLoad');
loadBtn.addEventListener('click', loadContacts);

let createBtn = document.getElementById('btnCreate');
createBtn.addEventListener('click', createContact);

let contactsUlElement = document.getElementById('phonebook');
contactsUlElement.addEventListener('click', removeContact);

let personNameElement = document.getElementById('person');
let personPhoneElement = document.getElementById('phone');

let url = 'http://localhost:3030/jsonstore/phonebook/';

async function loadContacts() {
    contactsUlElement.replaceChildren();
    
    try {
        let responce = await fetch(url);
        let result = await responce.json();
        
        Object.entries(result).forEach(contact => {
            let liContact = document.createElement('li');
            liContact.textContent = `${contact[1].person}: ${contact[1].phone} `;
            liContact.id = contact[0];

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';

            liContact.appendChild(deleteBtn);

            contactsUlElement.appendChild(liContact);
        });
    } catch (error) {
        
    }
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

        await responce.json();

        personNameElement.value = '';
        personPhoneElement.value = '';
        
        loadContacts();
    } catch (error) {
        
    }
}

async function removeContact(e) {
    if(e.target.tagName != 'BUTTON') {
        return;
    }

    let contactKey = e.target.parentNode.id;
    let delUrl = url + contactKey;

    try {
        let responce = await fetch(delUrl, {
            method: 'delete'
        });

        await responce.json();
        loadContacts();
    } catch (error) {
        
    }
}