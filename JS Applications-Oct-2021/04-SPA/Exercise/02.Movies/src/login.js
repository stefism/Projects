import { updateNav } from './app.js';
import { showView } from './dom.js';
import { showHome } from './home.js';

const section = document.getElementById('form-login');

const form = section.querySelector('form');
form.addEventListener('submit', onLogin);

section.remove();

export function showLogin() {
    showView(section);
}

async function onLogin(e) {
    e.preventDefault();

    const formData = new FormData(form);
    
    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    try {
        const response = await fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email, password})
        });

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const data = await response.json();

        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }));

        form.reset();
        updateNav();
        showHome();
    } catch (error) {
        alert(error.message);
    }
}