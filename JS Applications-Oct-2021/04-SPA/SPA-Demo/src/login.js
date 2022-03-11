import { updateUserNav } from "./app.js";
import { showSection, getFormElementValuesAsObject, request } from "./dom.js";
import { showHomePage } from "./home.js";

const section = document.getElementById('loginSection');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
// Топ левел кода се изпълнява само веднъж - при инициализацията. Затова няма опасност да закачим двоен евент лисенер.

export function showLoginPage() {
    showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formValues = getFormElementValuesAsObject(form);

    try {
        const result = await request('http://localhost:3030/users/login', {
            method: 'post',
            body: JSON.stringify(formValues)
        });

        const userData = {
            username: result.username,
            id: result._id,
            token: result.accessToken
        }

        sessionStorage.setItem('userData', JSON.stringify(userData));

        showHomePage();
    } catch (error) {
        alert(error.message);
    }

    updateUserNav();
}