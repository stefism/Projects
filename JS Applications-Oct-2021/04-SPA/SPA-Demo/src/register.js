import { updateUserNav } from "./app.js";
import { showSection, getFormElementValuesAsObject, request } from "./dom.js";
import { showHomePage } from "./home.js";

const section = document.getElementById('registerSection');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function showRegisterPage() {
    showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formValues = getFormElementValuesAsObject(form);

    if(formValues.password != formValues.rePassword) {
        alert('Passwords don\'t match.');
        return;
    }

    if(Object.values(formValues).some(field => field == '')) {
        alert ('Please fill all fields.');
        return;
    }

    delete formValues.rePassword;

    try {
        const result = await request('http://localhost:3030/users/register', {
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
        updateUserNav();
    } catch (error) {
        alert(error.message);
    }
}