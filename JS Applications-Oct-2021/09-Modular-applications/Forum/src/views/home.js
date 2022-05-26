import { html, until } from '../lib.js';
import { getTopicsCount } from '../../src/api/data.js';

const homeTemplate = (countPromise) => html`
<h1>Home</h1>
<div class="splash drop">
    <p>Welcome to forum.</p>
    <div>
        <a href="/Forum/topics">Browse ${until(countPromise, 'User Topics')}</a>
    </div>
</div>
`;

export function homePage(context) {
    context.render(homeTemplate(getTopicsCounter()));
    context.updateUserNav();
}

async function getTopicsCounter() {
    const count = await getTopicsCount();
    return `${count} User Topics`;
}