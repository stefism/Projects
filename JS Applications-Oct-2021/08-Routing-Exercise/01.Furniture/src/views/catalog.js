import { getAll, getMyItems } from '../api/data.js';
import { html, until } from '../lib.js';
import { getUserData, parseQuerystring } from '../util.js';

const catalogTemplate = (loadItemsPromise, isUserPage, onSearch, search) => html`
<div class="row space-top">
    <div class="col-md-12">
        ${isUserPage
        ? html`
            <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>
        `
        : html`
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        `}   
    </div>
    <div class="col-md-12">
        <form @submit=${onSearch}>
            <input type="text" name="search" .value=${search}>
            <input type="submit" value="Search">
        </form>
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

const pagerTemplate = (page, pages, search) => html`
<div class="row space-top">
    <a class="btn btn-info pages ${page == 1 ? ' disabled' : ''}" href=${createPageHref(page, -1, search)}>< Prev</a>
    <a class="btn btn-info pages disabled" href="?page=${page}">${page}</a>
    <a class="btn btn-info pages ${page == pages ? ' disabled' : ''}" href=${createPageHref(page, 1, search)}>Next ></a>
</div>
`;

function createPageHref(page, step, search) {
    return `?page=${page + step}` + (search ? `&search=${search}` : '');
}

export function catalogPage(context) {
    const query = parseQuerystring(context.querystring);
    const page = Number(query.page || 1);
    const search = query.search || '';

    const isUserPage = context.pathname == '/my-furniture';
    context.render(catalogTemplate(loadItems(isUserPage, page, search), isUserPage, onSearch, search));

    function onSearch(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const searchParam = formData.get('search').trim();

        if(searchParam) {
            context.page.redirect(`?search=${searchParam}`);
        } else {
            context.page.redirect('/');
        }
    }
}

async function loadItems(isUserPage, page, search) {
    let items = [];

    if(isUserPage) {
        const userId = getUserData().id;
        items = await getMyItems(userId);
    } else {
        items = await getAll(page, search);
    }

    return [
        pagerTemplate(page, items.pages, search),
        ...items.data.map(itemTemplate)
    ];
}