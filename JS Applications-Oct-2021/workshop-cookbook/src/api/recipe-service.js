import * as api from './api.js';
import { addOwner } from './data-service.js';

const pageSize = 5;

export async function getRecipes(page, query) {
    if(query) {
        query = {
            name: {
                $text: {
                    $search: {
                        $term: query
                    }
                }
            }
        };

        return api.get(`/classes/Recipe?where=${encodeURIComponent(JSON.stringify(query))}&skip=${(page - 1) * pageSize}&limit=${pageSize}&order=-createdAt`);
    }
    
    return api.get(`/classes/Recipe?skip=${(page - 1) * pageSize}&limit=${pageSize}&order=-createdAt`);
}

export async function getRecentRecipes() {
    return api.get('/classes/Recipe?limit=3&order=-createdAt');
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