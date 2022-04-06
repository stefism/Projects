import { createDomElement } from '../dom.js';

const section = document.getElementById('detailsPage');
section.remove();

export async function showDetailsPage(context) {
    context.showSection(section);
}