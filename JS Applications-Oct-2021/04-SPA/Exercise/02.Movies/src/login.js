import { showView } from './dom.js';

const section = document.getElementById('form-login');
section.remove();

export function showLogin() {
    showView(section);
}