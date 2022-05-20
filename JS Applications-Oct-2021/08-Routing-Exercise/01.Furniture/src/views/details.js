import { deleteItem, getById } from '../api/data.js';
import { showModal } from '../common/modal.js';
import { html, until } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (itemPromise) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    ${until(itemPromise, html`<p>Loading...</p>`)}
</div>
`;

const furnitureTemplate = (item, deleteItemById) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src=${item.img.includes('http') ? item.img : item.img.substring(1)} />
        </div>
    </div>
</div>
<div class="col-md-4">
    <p>Make: <span>${item.make}</span></p>
    <p>Model: <span>${item.model}</span></p>
    <p>Year: <span>${item.year}</span></p>
    <p>Description: <span>${item.description}</span></p>
    <p>Price: <span>${item.price}</span></p>
    <p>Material: <span>${item.material}</span></p>
    <div>
        ${item.isOwner
            ? html`
                <a href=${`/edit/${item._id}`} class="btn btn-info">Edit</a>
                <a @click=${deleteItemById} href="javascript:void(0)" class="btn btn-red">Delete</a>`
            : null}
    </div>
</div>
`;

export function detailsPage(context) {
    context.render(detailsTemplate(loadItem(context)));
}

async function loadItem(context) {
    const item = await getById(context.params.id);
    item.isOwner = item._ownerId == getUserData().id;
    
    return furnitureTemplate(item, () => deleteItemById(context, item));
}

async function deleteItemById(context, item) {
    showModal(`Are you sure to delete item ${item.make}, model ${item.model}?`, currentCallback);

    async function currentCallback(choice) {
        if(choice) {
            await deleteItem(context.params.id);
            context.page.redirect('/');
        }
    }

    // if(confirm(`Are you sure to delete item ${item.make}, model ${item.model}?`)) {
    //     await deleteItem(context.params.id);
    //     context.page.redirect('/');
    // }
}