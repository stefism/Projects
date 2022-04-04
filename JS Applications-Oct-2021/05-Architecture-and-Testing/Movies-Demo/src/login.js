import * as api from './api/data.js'

const section = document.getElementById('loginSection');
let currContext = null;

section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
// Топ левел кода се изпълнява само веднъж - при инициализацията. Затова няма опасност да закачим двоен евент лисенер.

export function showLoginPage(context) {
    currContext = context;
    currContext.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');

    await api.login(email, password);
    
    currContext.updateUserNav();
    currContext.goTo('home');
}