import { createNewTopic } from '../api/data.js';
import { html } from '../lib.js';
import { getAllFormEntriesAsObject } from '../util.js';

const createTemplate = (onCreate) => html`
<div class="narrow drop">
    <h1>Create New Topic</h1>
    <form @submit = ${onCreate}>
        <label><span>Title</span><input type="text", name="title"></label>
        <label><span>Description</span><textarea name="description"></textarea></label>
        <div class="center">
            <input class="action" type="submit" , value="Publish">
        </div>
    </form>
</div>
`;

export function createPage(context) {
    context.render(createTemplate((e) => onCreate(e, context.page)));
}

async function onCreate(e, page) {
    e.preventDefault();

    const formEntries = getAllFormEntriesAsObject(e.target);
    
    await createNewTopic(formEntries);
    page.redirect('/Forum/topics');
}