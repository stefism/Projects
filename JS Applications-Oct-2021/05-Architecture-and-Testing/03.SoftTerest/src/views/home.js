import { createDomElement } from '../dom.js';

const section = document.getElementById('homePage');
section.remove();

export async function showHomePage(context) {
    context.showSection(section);
}