import { logout } from './api/data.js';
import { render, page} from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { topicsPage } from './views/topics.js';

const main = document.querySelector('main');

document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/Forum/index.html', homePage);
page('/Forum/topics', topicsPage);
page('/Forum/topic/:id', detailsPage);
page('/Forum/login', loginPage);
page('/Forum/create', createPage);
page('/Forum/register', registerPage);

updateUserNav();
page.start();

function decorateContext(context, next) {
    context.render = (content) => render(content, main);
    context.updateUserNav = updateUserNav;
    next();
}

async function onLogout() {
    await logout();
    page.redirect('/Forum/index.html');
}

function updateUserNav() {
    const userData = getUserData();

    if(userData) {
        [...document.querySelectorAll('.user')].forEach(e => e.style.display = 'inline-block');
        [...document.querySelectorAll('.guest')].forEach(e => e.style.display = 'none');
    } else {
        [...document.querySelectorAll('.user')].forEach(e => e.style.display = 'none');
        [...document.querySelectorAll('.guest')].forEach(e => e.style.display = 'inline-block');
    }
}