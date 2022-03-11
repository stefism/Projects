import { showView } from './dom.js';

const section = document.getElementById('home-page');
section.remove();

export function showHome() {
    showView(section);
}