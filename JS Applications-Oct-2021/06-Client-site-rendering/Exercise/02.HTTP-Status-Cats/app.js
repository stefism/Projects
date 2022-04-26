import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const catElement = document.getElementById('allCats');
// const ul = document.createElement('ul');
// catElement.appendChild(ul);

const catCardTemplate = (cat) => html`
<li>
   <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
   <div class="info">
       <button class="showBtn" @click=${() => onDetails(cat)}>${cat.details ? 'Hide' : 'Show'} status code</button>
       <div class="status" style="display: ${cat.details ? 'block' : 'none'}" id=${cat.id}>
           <h4>Status Code: ${cat.statusCode}</h4>
           <p>${cat.statusMessage}</p>
       </div>
   </div>
</li>`;

function onDetails(cat) {
    cat.details = !(cat.details);
    onRender();
}

function onRender() {
    // render(cats.map(catCardTemplate), ul);
    render(html`<ul>${cats.map(catCardTemplate)}</ul>`, allCats);
}

onRender();