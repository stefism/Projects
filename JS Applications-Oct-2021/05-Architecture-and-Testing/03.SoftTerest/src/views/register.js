import { register } from "../api/data.js";

let currContext = null;

const section = document.getElementById('registerPage');
section.remove();

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export async function showRegisterPage(context) {
    currContext = context;
    currContext.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repass = formData.get('repeatPassword').trim();

    if (!email || !password) {
        return alert ('All fields are required.')
    }

    if(password != repass) {
        return alert ('Passwords don\'t match.')
    }

    await register(email, password);
    form.reset();
    
    currContext.goTo('home');
    currContext.updateNav();
}