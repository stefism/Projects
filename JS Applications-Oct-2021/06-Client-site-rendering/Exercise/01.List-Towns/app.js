import { html, render } from '../node_modules/lit-html/lit-html.js';

// const townTemplate = (town) => html`<li>${town}</li>`;

const townsTemplate = (towns) => html`
<ul>
    ${towns.map(t => html`<li>${t}</li>`)}
</ul>`;

const root = document.getElementById('root');
// const ul = document.createElement('ul');
// root.appendChild(ul);

const form = document.querySelector('form');
form.addEventListener('submit', onSubmut);

function onSubmut(e) {
    e.preventDefault();

    const formData = new FormData(form);
    const towns = formData.get('towns').split(', ');

    render(townsTemplate(towns), root);

    form.reset();
}
