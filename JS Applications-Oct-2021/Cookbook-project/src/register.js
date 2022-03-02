const registerForm = document.querySelector('form');
registerForm.addEventListener('submit', onRegister);

async function onRegister(e) {
    const url = 'http://localhost:3030/users/register';

    e.preventDefault();
    const formData = new FormData(registerForm);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repass = formData.get('rePass').trim();

    if(password != repass) {
        alert('Password and repeat password dont match.');
        return;
    }

    try {
        const responce = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });
    
        const resData = await responce.json();
        console.log(resData);

        sessionStorage.setItem('authToken', resData.accessToken); //Сървъра връща токен за оторизация и така го запазваме в сешън сторижа.
        // window.location = '/index.html';
    } catch (error) {
        alert(error.message);
    }
}