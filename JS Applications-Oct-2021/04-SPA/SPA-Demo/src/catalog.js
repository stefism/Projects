import { updateUserNav } from "./app.js";
import { showSection, createDomElement } from "./dom.js";
import { showLoginPage } from "./login.js";

const catalogSection = document.getElementById('catalogSection');
const ul = catalogSection.querySelector('ul');
catalogSection.remove();

export function showCatalogPage() {
    showSection(catalogSection);

    loadMovies();
}

async function loadMovies() {
    ul.replaceChildren(createDomElement('p', {}, 'Loading...'));

    const options = { method: 'get', headers: {} };
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if(userData == null) {
        options.headers['X-Authorizaton'] = userData.token;
    }

    const response = await fetch('http://localhost:3030/data/movies', options);

    if(response.status == 403) {
        sessionStorage.removeItem('userData');
        updateUserNav();
        showLoginPage();
    } // Тука се подсигуряваме в случай, че сървъра се рестартира. Тогава чистиме sessionStorage иначе приложението ще си мисли, че е логнато. 403 е невалиден токен в този случай.

    const movies = await response.json();

    ul.replaceChildren(...movies.map(createMovieCard));
}

function createMovieCard(movie) {
    return createDomElement('li', {}, movie.title);
}