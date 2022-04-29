import { showCatalog } from './catalog.js';
import { showCreate } from './create.js';
import { render } from './utility.js';

const root = document.body;

const context = {
    render: (template) => render(template, root)
};

context.render([
    showCatalog(context),
    showCreate(context)
]);