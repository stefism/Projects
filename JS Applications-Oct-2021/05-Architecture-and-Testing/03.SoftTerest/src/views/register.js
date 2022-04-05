import { createDomElement } from '../dom.js';

const section = document.getElementById('registerPage');
section.remove();

export async function showRegisterPage(context) {
    context.showSection(section);
}