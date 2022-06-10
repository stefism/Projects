import { getRecipeById, updateRecipe } from '../api/recipe-service.js';
import { html } from '../lib.js';
import { createSubmitHandler } from '../util.js';
import { field } from './common.js';

const editTemplate = (onSubmit, errors, data) => html`
<section id="create">
    <article>
        <h2>Edit Recipe</h2>
        <form @submit=${onSubmit} id="editForm">
            ${errors ? html`<p class="error">${errors.message}</p>` : null}

            ${field({
                label: 'Name', 
                name: 'name', 
                value: data.name, 
                placeholder: 'Recipe name', 
                error: errors.name
            })}

            ${field({
                label: 'Image', 
                name: 'img', 
                value: data.img, 
                placeholder: 'Image URL', 
                error: errors.img
            })}

            ${field({
                label: 'Ingredients', 
                type: 'textarea', 
                name: 'ingredients', 
                value: data.ingredients, 
                placeholder: 'Enter ingredients on separate lines', 
                error: errors.ingredients
            })}

            ${field({
                label: 'Preparations', 
                type: 'textarea', 
                name: 'steps', 
                value: data.steps, 
                placeholder: 'Enter preparation steps on separate lines', 
                error: errors.steps
            })}

            <input type="submit" value="Edit Recipe">
        </form>
    </article>
</section>
`;

export async function editPage(context) {
    const recipe = await getRecipeById(context.params.id);
    recipe.ingredients = recipe.ingredients.join('\n');
    recipe.steps = recipe.steps.join('\n');
    
    update();

    function update(errors = {}, data = recipe) {
        context.render(
                editTemplate(
                createSubmitHandler(onSubmit, 'name', 'img', 'ingredients', 'steps'), 
                errors,
                data
            )
        );
    }
    
    async function onSubmit(data, event) {
        try {
            const missing = Object.entries(data).filter(([k, v]) => v == '');
            
            if(missing.length > 0) {
                throw missing.reduce((a, [key]) => Object.assign(a, { [key]: true }), {message: 'Please fill all fields.'});
            }

            const recipe = {
                name: data.name,
                img: data.img,
                ingredients: data.ingredients.split('\n').filter(r => r != ''),
                steps: data.steps.split('\n').filter(r => r != '')
            };
    
            await updateRecipe(context.params.id, recipe);
            
            event.target.reset();
            
            context.notify('Recipe updated');

            context.page.redirect('/details/' + context.params.id);
        } catch (error) {
            update(error, data);
        }
    }
}