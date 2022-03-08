const loginForm = document.getElementById('login');
loginForm.addEventListener('submit', onLogin);

const registerForm = document.getElementById('register');
registerForm.addEventListener('submit', onRegister);

async function onRegister(e) {
    e.preventDefault();

    const formData = new FormData(registerForm);
    
    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('rePass');
}

async function onLogin(e) {
    e.preventDefault();

    const formData = new FormData(loginForm);
    
    const email = formData.get('email');
    const password = formData.get('password');

    try {
        const responce = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if(responce.status != 200) {
            const error = await responce.json();
            throw new Error(`Error: ${error.message}`);
        }

        const resData = await responce.json();
        sessionStorage.setItem('authToken', resData.accessToken);
        sessionStorage.setItem('userId', resData._id);
        sessionStorage.setItem('email', resData.email);

        window.location = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}