import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const townsElement = document.getElementById('towns');
const searchTextElement = document.getElementById('searchText');
const resultElement = document.getElementById('result');

document.querySelector('button').addEventListener('click', onClick);

let townsObj = towns.map(t => ({town: t, match: false})); //Тука трябва още едни е такива () скоби, защото иначе интерпретатора ще си мисли, че искаме да напишем функция на няколко реда, а ние в случая искаме да върнем обект.

const template = (town, symbol) => html`<li class="${town.match ? 'active' : 'none'}">${symbol}${town.town}</li>`;

function onClick() {
    const searchText = searchTextElement.value;
    let matches = 0;

    if(searchText != ''){
        townsObj.forEach(t => {
            if(t.town.includes(searchText)) {
                t.match = true;
                matches++;
            } else {
                t.match = false;
            }
        });
    }

    onRender();
    resultElement.textContent = `${matches} matches found`;
}

function onRender() {
    render(html`<ul>${townsObj.map(t => template(t, '*** '))}</ul>`, townsElement);
}

onRender();