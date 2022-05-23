import { html } from '../lib.js';

const homeTemplate = () => html`
<h1>Home</h1>
<div class="splash drop">
    <p>Welcome to forum.</p>
    <div>
        <a href="/Forum/topics">Browse User Topics</a>
    </div>
</div>
`;

export function homePage(context) {
    context.render(homeTemplate());
    context.updateUserNav();
}