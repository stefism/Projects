import { getRecentRecipes } from '../api/recipe-service.js';
import { html, until } from '../lib.js';
import { spinner } from './common.js';

const homeTemplate = (recipePromise) => html`
<section id="home">
    <div class="hero">
        <h2>Welcome to My Cookbook</h2>
    </div>
    <header class="section-title">Recently added recipes</header>
    <div class="recent-recipes">

        ${until(recipePromise, spinner())}

    </div>
    <footer class="section-title">
        <p>Browse all recipes in the <a href="/catalog">Catalog</a></p>
    </footer>
</section>
`;

const recipePreview = (recipe, count) => html`
<a class="card" href="/details/${recipe.objectId}">
    <article class="recent">
        <div class="recent-preview"><img src="${recipe.img}"></div>
        <div class="recent-title">${recipe.name}</div>
    </article>
</a>

${count < 3 ? html`<div class="recent-space"></div>` : null}
`;

export function homePage(context) {
    context.render(homeTemplate(loadRecipes()));
}

async function loadRecipes() {
    const recipes = await getRecentRecipes();

    if(recipes.results.length == 0) {
        return html`<p>No recipes found.</p>`;
    }

    let count = 0;
    return recipes.results.map(r => {
        count++;
        return recipePreview(r, count);
    });
}