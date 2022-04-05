import { createDomElement } from '../dom.js';

const section = document.getElementById('loginPage');
section.remove();

export async function showLoginPage(context) {
    context.showSection(section);
}