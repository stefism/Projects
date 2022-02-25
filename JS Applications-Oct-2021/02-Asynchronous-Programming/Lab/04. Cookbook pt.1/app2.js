window.addEventListener('DOMContentLoaded', start);

async function start() {
    const main = document.querySelector('main');

    const recipes = await getRecipes();
    main.replaceChildren();

    recipes.map(createPreview).forEach(e => main.appendChild(e));
}

function createPreview(recipe) {
    const articleElement = document.createElement('article');
    articleElement.className = 'preview';

    //innerHTML - само за учебни цели за да стане по-бързо. Иначе не се прави така. Трябва по отделно да си се създават елементите и да си се нестват после един в друг.
    articleElement.innerHTML = `<div class="title">
                                    <h2>${recipe.name}</h2>
                                </div>
                                <div class="small">
                                    <img src="${recipe.img}">
                                </div>`;

    articleElement.addEventListener('click', () => {
        articleElement.querySelector('h2').textContent = 'Loading...';
        togglePreview(recipe._id, articleElement);
    });
    
    return articleElement;
}

async function togglePreview(id, preview) {
    const recipe = await getRecipeById(id);
    
    const articleElement = document.createElement('article');
    articleElement.innerHTML = 
    `<h2>${recipe.name}</h2>
    <div class="band">
        <div class="thumb">
            <img src="${recipe.img}">
        </div>
        <div class="ingredients">
            <h3>Ingredients:</h3>
            <ul>
                ${recipe.ingredients.map(i => `<li>${i}</li>`).join('\n')}
            </ul>
        </div>
    </div>
    <div class="description">
        <h3>Preparation:</h3>
        ${recipe.steps.map(i => `<p>${i}</p>`).join('\n')}
    </div>`;

    preview.replaceWith(articleElement);
}

async function getRecipes() {
    const result = await fetch('http://localhost:3030/jsonstore/cookbook/recipes');
    const data = await result.json();

    return Object.values(data);
}

async function getRecipeById(id) {
    const result = await fetch('http://localhost:3030/jsonstore/cookbook/details/' + id);
    const data = await result.json();

    return data;
}