import { html, updateBook } from './utility.js';

const updateTemplate = (book, context) => html`
<form @submit=${ev => onSubmit(ev, context)} id="edit-form">
   <input type="hidden" name="id" .value=${book._id}> <!-- .value={нещо} - така се популират данните в lit-html -->
   <h3>Edit book</h3>
   <label>TITLE</label>
   <input type="text" name="title" placeholder="Title..." .value=${book.title}>
   <label>AUTHOR</label>
   <input type="text" name="author" placeholder="Author..." .value=${book.author}>
   <input type="submit" value="Save">
</form>
`;

export function showUpdate(context) {
    if(context.book == undefined) {
        return null; //Когато рендера види null, той не отпечатва нищо. Така работи lit-html.
    } else {
        return updateTemplate(context.book, context);
    }
}

async function onSubmit(e, context) {
    e.preventDefault();

    const formData = new FormData(e.target);

    const id = formData.get('id');
    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    await updateBook(id, { title, author });

    e.target.reset();
    delete context.book;
    context.update();
}