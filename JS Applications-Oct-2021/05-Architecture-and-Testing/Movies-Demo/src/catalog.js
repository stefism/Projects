import { getAllMovies } from "./api/data.js";
import { createDomElement } from "./dom.js";

const catalogSection = document.getElementById('catalogSection');
const ul = catalogSection.querySelector('ul');
catalogSection.remove();

export function showCatalogPage(context) {
    context.showSection(catalogSection);

    loadMovies();
}

async function loadMovies() {
    ul.replaceChildren(createDomElement('p', {}, 'Loading...'));

    const movies = await getAllMovies();

    ul.replaceChildren(...movies.map(createMovieCard));
}

function createMovieCard(movie) {
    return createDomElement('li', {}, movie.title);
}