import { logout } from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

//Ако искаме да си тестваме функциите през конзолата на браузъра, пишем тези два реда.
// import * as api from './api/data.js';
// window.api = api;

const root = document.querySelector('div.container');

document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext); //Така, това ще се изпълни винаги преди останалите. Това е мидълуер.

page('/index.html', '/');
page('/', catalogPage);
page('/details/:id', detailsPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/login', loginPage);
page('/register', registerPage);
page('/my-furniture', catalogPage);

updateUserNav();
page.start();

function decorateContext(context, next) {
    context.render = (content) => render(content, root);
    context.updateUserNav = updateUserNav;

    next(); //Задължително, иначе тези след него няма да се изпълнят.
}

function updateUserNav() {
    const userData = getUserData();

    if(userData) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

async function onLogout() {
    await logout();
    updateUserNav();

    page.redirect('/');
}