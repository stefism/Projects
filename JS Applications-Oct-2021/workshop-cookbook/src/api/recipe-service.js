import * as api from './api.js';
import { addOwner } from './data-service.js';

export async function getRecipes() {
    return api.get('/classes/Recipe');
}

export async function getRecipeById(id) {
    return api.get(`/classes/Recipe/${id}?include=owner`);
}

export async function createRecipe(recipe) {
    addOwner(recipe);

    return api.post('/classes/Recipe', recipe);
}

export async function updateRecipe(id, recipe) {
    return api.put('/classes/Recipe/' + id, recipe);
}

export async function deleteRecipe(id) {
    return api.del('/classes/Recipe/' + id);
}