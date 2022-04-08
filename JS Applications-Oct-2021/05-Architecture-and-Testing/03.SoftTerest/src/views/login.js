import { login } from "../api/data.js";

let currContext = null;

const section = document.getElementById('loginPage');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export async function showLoginPage(context) {
    currContext = context;
    currContext.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    await login(email, password);
    form.reset();

    currContext.goTo('home');
    currContext.updateNav();
}