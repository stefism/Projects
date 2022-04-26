import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const body = document.querySelector('body');

let townsObj = [];

towns.forEach(t => townsObj.push({town: t, match: false}));
console.log(townsObj);

//Не забравяй, нещата дето се подават да са винаги през конструктора на функцията за да може отчете ако има нещо променено. Ако няма конструктор и ги вземе направо от променливата горе, не ги променя после.
const template = (towns, symbol) => html`
<article>
   <div id="towns">
       <ul>
           ${towns.map(t => html`<li class="${t.match ? 'active' : 'none'}">${symbol}${t.town}</li>`)}
       </ul>
   </div>
   <input type="text" id="searchText" />
   <button @click=${() => onClick()}>Search</button>
   <div id="result"></div>
</article>
`;

function onClick() {
    const searchText = document.getElementById('searchText');
    const resultElement = document.getElementById('result');
    
    console.log('searchText', searchText.value);
    let matches = 0;

    townsObj.forEach(t => {
        if(t.town.includes(searchText.value)) {
            t.match = true;
            matches++;
        } else {
            t.match = false;
        }
    });

    console.log(townsObj);
    onRender();
    resultElement.textContent = `${matches} matches found`;
}

function onRender() {
    render(template(townsObj, '*** '), body);
}

onRender();