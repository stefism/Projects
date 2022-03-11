import { showView } from './dom.js';

const section = document.getElementById('movie-details');
section.remove();

export function showDetails() {
    showView(section);
}