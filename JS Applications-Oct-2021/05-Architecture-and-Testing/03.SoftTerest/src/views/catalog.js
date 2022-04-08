import { createDomElement } from '../dom.js';
import { getAllIdeas } from '../api/data.js';

let currContext = null;

const section = document.getElementById('dashboard-holder');
section.remove();

section.addEventListener('click', onDetails);

export async function showCatalogPage(context) {
    currContext = context;
    currContext.showSection(section);
    loadIdeas();
}

async function loadIdeas() {
    const ideas = await getAllIdeas();

    if(ideas.length == 0) {
        section.replaceChildren(createDomElement('h1', {}, 'No ideas yet. Be the first one :)'));
    } else {
        const fragment = document.createDocumentFragment();
        ideas.map(createIdeaCard).forEach(i => fragment.appendChild(i)); 
        section.replaceChildren(fragment);
    }
     
}

function createIdeaCard(idea) {
    const element = createDomElement('div', { className: 'card overflow-hidden current-card details'});
    element.style.width = '20rem';
    element.style.height = '18rem';

    element.innerHTML = `
    <div class="card-body">
       <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a data-id="${idea._id}" class="btn" href="">Details</a>`;

    return element;
}

function onDetails(e) {
    if (e.target.tagName == 'A') {
        e.preventDefault();
        const id = e.target.dataset.id;
        currContext.goTo('details', id);
    }
}