import * as api from './api.js';
import { addOwner, createPointer } from './data-service.js';

export function getCommentsByRecipeId(recipeId) {
    return api.get(`/classes/Comment?where=${ createPointerQuery('recipe', 'Recipe', recipeId) }&include=owner&order=-createdAt`);
}

export function createComment(recipeId, comment) {
    comment.recipe = createPointer('Recipe', recipeId);
    addOwner(comment);

    return api.post('/classes/Comment', comment);
}

function createPointerQuery(propName, className, objectId) {
    return createQuery({[propName]: createPointer(className, objectId)});
}

function createQuery(query) {
    return encodeURIComponent(JSON.stringify(query));
}