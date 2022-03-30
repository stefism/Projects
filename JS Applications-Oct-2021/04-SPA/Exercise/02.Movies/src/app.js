import { getDataFromSessionStorage } from './dom.js';
import { showHome } from './home.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';

const views = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister
};

const nav = document.querySelector('nav');

document.getElementById('logoutBtn').addEventListener('click', onLogout);

nav.addEventListener('click', (e) => {
    const view = views[e.target.id];

    if(typeof view == 'function') {
        e.preventDefault();

        view();
    }
});

updateNav();
showHome();

export function updateNav() {
    const userData = getDataFromSessionStorage('userData');

    if (userData != null) {
        nav.querySelector('#welcomeMessage').textContent = `Welcome, ${userData.email}`;

        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'none');
        // Понеже .user .guest са поредица от елементи, за да ги форичнем, трябва да ги обърнем в масив и това го правим с [...].
    } else {
        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'block');
    }
}

async function onLogout(e) {
    e.preventDefault();
    e.stopImmediatePropagation(); //Казва на ивент лисенерите след този, да не се изпълняват. В случая го правим защото на Logout бутона имаме закачени два ивент лисенери. Единия е от nav.addEventListener('click', (e) =>, а другия от document.getElementById('logoutBtn').addEventListener('click', onLogout); и за да не се изпълни nav, на този му слагаме stopImmediatePropagation. За да работи това правилно, горе лисенерите трябва да са подредени един след друг в правилния ред. Този дето спира викането на тези дето са след него, съответно трябва да е преди тези на което спира извикването.

    const {token} = JSON.parse(sessionStorage.getItem('userData')); //Като деструктурираме от обект го правим с {} и си пишем в тези скоби, пропертито, което искаме да вземем.

    await fetch('http://localhost:3030/users/logout', {
        headers: {
            'X-Authorization': token
        }
    }); //Ако не сложим в option-ите на заявката (fetch) метод, то си приема, че метода е get.

    sessionStorage.removeItem('userData'); //Не ползваме .clear() защото то изчиства всичко от сториджа, а може да имаме друг неща там, които не искаме да премахнем.
    updateNav();
    showHome();
}