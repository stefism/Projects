import { deleteRecipe, getRecipeById } from '../api/recipe-service.js';
import { html, until } from '../lib.js';
import { commentsView } from './comments.js';
import { spinner } from './common.js';

const detailsTemplate = (recipePromise) => html`
<section id="details">
    ${until(recipePromise, spinner())}
    
    <div id="comments-container"></div>
</section>
`;

const recipeCard = (recipe, isOwner, onDelete) => html`
<article>
    <h2>${recipe.name}</h2>
    <div class="band">
        <div class="thumb"><img src=${recipe.img}></div>
        <div class="ingredients">
            <h3>Ingredients:</h3>
            <ul>
                ${recipe.ingredients.map(ingredient => html`<li>${ingredient}</li>`)}
            </ul>
        </div>
    </div>
    <div class="description">
        <h3>Preparation:</h3>
        ${recipe.steps.map(step => html`<p>${step}</p>`)}

    </div>
    <div class="controls">
        ${isOwner ? html`
            <a class="actionLink" href="/edit/${recipe.objectId}">&#x270e; Edit</a>
            <a @click=${onDelete} class="actionLink" href="javascript:void(0)">&#x2716; Delete</a>
        ` : null}
    </div>
</article>
`;

export function detailsPage(context) {
    context.render(detailsTemplate(loadRecipe(context)));
    commentsView(context, context.params.id);
}

async function loadRecipe(context) {
    const recipe = await getRecipeById(context.params.id);
    const isOwner = context.user && context.user.id == recipe.owner.objectId;
    //&& Ако имаме context.user тогава проверяваме дали context.user.id == recipe.owner.objectId

    return recipeCard(recipe, isOwner, onDelete);

    async function onDelete() {
        if(confirm('Are you sure to delete this recipe?')) {
            await deleteRecipe(context.params.id);
            context.notify('Recipe deleted');
            context.page.redirect('/catalog');
        }
    }
}