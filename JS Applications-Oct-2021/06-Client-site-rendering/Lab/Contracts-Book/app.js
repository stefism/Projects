import { contacts } from './contacts.js';
import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { styleMap } from '../../node_modules/lit-html/directives/style-map.js';

const contactTemplate = (contact, onDetails) => html`
   <div class="contact card">
       <div>
           <i class="far fa-user-circle gravatar"></i>
       </div>
       <div class="info">
           <h2>Name: ${contact.name}</h2>
           <button class="detailsBtn" @click=${() => onDetails(contact)}>${contact.details ? 'Hide' : 'Details'}</button>
           <div class="details" id=${contact.id} style=${styleMap({display: contact.details ? 'block' : 'none'})}>
               <p>Phone number: ${contact.phoneNumber}</p>
               <p>Email: ${contact.email}</p>
           </div>
       </div>
   </div>
`;

start();

function start() {
    const container = document.getElementById('contacts');

    onRender();

    function onDetails(contact) {
        contact.details = !(contact.details);
        onRender();
    }

    function onRender() {
        render(contacts.map(contact => contactTemplate(contact, onDetails)), container);
    }
}