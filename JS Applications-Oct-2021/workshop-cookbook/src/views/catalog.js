import { getRecipes } from '../api/recipe-service.js';
import { html, until } from '../lib.js';
import { createSubmitHandler, parseQuery } from '../util.js';
import { spinner } from './common.js';

const catalogTemplate = (catalogPromise, onSearch, page = 1, searchValue = '') => html`
<section id="catalog">
    <div class="section-title">
        <form @submit=${onSearch} id="searchForm">
            <input id="catalog-input" type="text" name="search" .value=${searchValue}>
            <input id="catalog-submit" type="submit" value="Search">
        </form>
    </div>

    <header class="section-title">
        Page ${page}
        ${page > 1 ? html`<a class="pager" href="/catalog/?page=${page - 1}">< Prev</a>` : null}
        <a class="pager" href="/catalog/?page=${Number(page) + 1}">Next ></a>
    </header>

    ${until(catalogPromise, spinner())}

    <footer class="section-title">
        Page ${page}
        ${page > 1 ? html`<a class="pager" href="/catalog/?page=${page - 1}">< Prev</a>` : null}
        <a class="pager" href="/catalog/?page=${page + 1}">Next ></a>
    </footer>
</section>
`;

const recipePreview = (recipe) => html`
<a class="card" href="/details/${recipe.objectId}">
  <article class="preview">
      <div class="title">
          <h2>${recipe.name}</h2>
      </div>
      <div class="small"><img src=${recipe.img}></div>
  </article>
</a>
`;

export function catalogPage(context) {
    const { page, search } = parseQuery(context.querystring);

    context.render(catalogTemplate(loadRecipes(page, search), createSubmitHandler(onSearch, 'search'), page, search));

    function onSearch({ search }) {
        if(search) {
            context.page.redirect(`/catalog?search=${encodeURIComponent(search)}`);
        } else {
            context.page.redirect('/catalog');
        }
    }
}

async function loadRecipes(page = 1, search = '') {
    const recipes = await getRecipes(page, search);

    if(recipes.results.length == 0) {
        return html`<p>No recipes found.</p>`;
    }

    return recipes.results.map(recipePreview);
}