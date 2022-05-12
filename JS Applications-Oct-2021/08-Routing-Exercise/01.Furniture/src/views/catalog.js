import { getAll } from '../api/data.js';
import { html, until } from '../lib.js';

const catalogTemplate = (loadItemsPromise) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
    ${until(loadItemsPromise, html`<p>Loading...</p>`)}
</div>
`;

const itemTemplate = (item) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src=${item.img} />
            <p>${item.description}</p>
            <footer>
                <p>Price: <span>${item.price} $</span></p>
            </footer>
            <div>
                <a href=${`/details/${item._id}`} class="btn btn-info">Details</a>
            </div>
        </div>
    </div>
</div>
`;

export function catalogPage(context) {
    context.render(catalogTemplate(loadItems()));
}

async function loadItems() {
    const items = await getAll();

    return items.map(itemTemplate);
}