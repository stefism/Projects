import { createBook, html } from './utility.js';

const createTemplate = (contextUpdate) => html`
<form @submit=${ev => onSubmit(ev, contextUpdate)} id="add-form">
   <h3>Add book</h3>
   <label>TITLE</label>
   <input type="text" name="title" placeholder="Title...">
   <label>AUTHOR</label>
   <input type="text" name="author" placeholder="Author...">
   <input type="submit" value="Submit">
</form>
`;

export function showCreate(context) {
    if(context.book == undefined) {
        return createTemplate(context.update);
    } else {
        return null;
    }
}

async function onSubmit(e, contextUpdate) {
    e.preventDefault();

    const formData = new FormData(e.target);

    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    await createBook({ title, author });

    e.target.reset();
    contextUpdate();
}