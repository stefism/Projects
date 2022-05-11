import { page, render } from './lib.js';
import { getUserData, loadMovie } from './util.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

const root = document.querySelector('main');

page('/index.html', decorateContext, catalogPage);
page('/', decorateContext, catalogPage); //Първо ще изпълни decorateContext, ще му подаде на него контекста и некст, после ще извика и catalogPage, като на него ще му подаде контекста, който идва от page и в него ще има нашето си добавео проперти .render
//Тук можем най-горе да му кажем page(decorateContext) и после долу да пишем само page('/', catalogPage);

page('/create', decorateContext, createPage);
page('/details/:id', decorateContext, loadMovie, detailsPage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/edit/:id', decorateContext, loadMovie, editPage);

// page('index.html', '/'); //Page redirect

updateUserNav();
page.start();

async function decorateContext(ctx, next) {
    console.log(ctx);
    ctx.render = (template) => render(template, root); //Паршъл апликейшън - функция, която приема два параметъра я правим да приема само един.
    ctx.updateUserNav = updateUserNav;
    next(); //Вика се за да може page след decorateContext да викне следващата функция, която в случая е catalogPage. decorateContext функцията в случая е middleware
}

function updateUserNav() {
    const userData = getUserData();

    if(userData) {
        [...document.querySelectorAll('nav .user')].forEach(e => e.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(e => e.style.display = 'none');
        document.getElementById('welcomeMessage').textContent = `Welcome, ${userData.email}`;
    } else {
        [...document.querySelectorAll('nav .user')].forEach(e => e.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(e => e.style.display = 'block');
    }
}