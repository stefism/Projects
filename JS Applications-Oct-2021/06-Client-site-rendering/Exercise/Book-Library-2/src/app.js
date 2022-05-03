import { showCatalog } from './catalog.js';
import { showCreate } from './create.js';
import { showUpdate } from './update.js';
import { render } from './utility.js';

const root = document.body;

const context = {
    update
};

update();

function update() {
    render([
        showCatalog(context),
        showCreate(context),
        showUpdate(context)
    ], root);
}