const loginForm = document.querySelector('form');
loginForm.addEventListener('submit', login)

async function login(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/login';

    const formData = new FormData(loginForm);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    try {
        const responce = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (responce.status != 200) {
            const error = await responce.json();
            throw new Error(`Error: ${error.message}`);
        }

        const result = await responce.json();
        sessionStorage.setItem('authToken', result.accessToken);

        window.location = '/index.html';
    } catch (error) {
        alert(error.message);
    }
}