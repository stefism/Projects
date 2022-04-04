import { register } from "./api/data.js";
import { getFormElementValuesAsObject } from "./dom.js";

const section = document.getElementById('registerSection');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

let currContext = null;

export function showRegisterPage(context) {
    currContext = context;
    currContext.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formValues = getFormElementValuesAsObject(form);

    if(formValues.password != formValues.rePassword) {
        alert('Passwords don\'t match.');
        delete formValues.rePassword;
        return;
    }

    if(Object.values(formValues).some(field => field == '')) {
        alert ('Please fill all fields.');
        return;
    }

    await register(formValues.email, formValues.password);

    currContext.updateUserNav();
    currContext.goTo('home');
}