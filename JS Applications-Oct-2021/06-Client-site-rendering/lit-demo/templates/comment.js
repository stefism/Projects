import { html } from 'https://unpkg.com/lit-html?module';

const commentTemplate = (comment) => html`<li>${comment.content}</li>`;

export default commentTemplate;