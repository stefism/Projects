import { page, render } from './lib.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

//Ако искаме да си тестваме функциите през конзолата на браузъра, пишем тези два реда.
import * as api from './api/data.js';
window.api = api;

const root = document.querySelector('div.container');

page(decorateContext); //Така, това ще се изпълни винаги преди останалите. Това е мидълуер.

page('/', catalogPage);
page('/details/:id', detailsPage);
page('/create', createPage);
page('/edit/:id', editPage);
page('/login', loginPage);
page('/register', registerPage);
page('/my-furniture', catalogPage);

page.start();

function decorateContext(context, next) {
    context.render = (content) => render(content, root);

    next(); //Задължително, иначе тези след него няма да се изпълнят.
}