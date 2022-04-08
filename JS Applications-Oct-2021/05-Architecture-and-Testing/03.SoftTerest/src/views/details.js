import { deleteById, getById } from '../api/data.js';
import { createDomElement } from '../dom.js';

const section = document.getElementById('detailsPage');
section.remove();

let currContext = null;

export async function showDetailsPage(context, id) {
    currContext = context;
    currContext.showSection(section);
    loadIdea(id);
}

async function loadIdea(id) {
    const idea = await getById(id);
    section.replaceChildren(createIdeaDiv(idea));
}

function createIdeaDiv(idea) {
    const fragment = document.createDocumentFragment();

    fragment.appendChild(createDomElement('img', { className: 'det-img', src: idea.img }));
    fragment.appendChild(createDomElement('div', { className: 'desc' },
        createDomElement('h2', { className: 'display-5' }, idea.title),
        createDomElement('p', { className: 'infoType' }, 'Description'),
        createDomElement('p', { className: 'idea-description' }, idea.description))
    );

    const userData = JSON.parse(sessionStorage.getItem('userData'));
    
    if(userData && userData.id == idea._ownerId) {
        fragment.appendChild(createDomElement('div', { className: 'text-center' },
            createDomElement('a', { className: 'btn detb', href: '', onClick: onDelete }, 'Delete')
        ));
    }

    return fragment;

    async function onDelete(e) {
        e.preventDefault();

        const confirmed = confirm('Are you sure to delete idea?');

        if(confirmed) {
            await deleteById(idea._id);
            currContext.goTo('catalog');
        }
    }
}