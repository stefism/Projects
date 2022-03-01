window.onload = loadRecipes;

async function loadRecipes() {
    try {
        const responce = await fetch('http://localhost:3030/jsonstore/cookbook');
        const data = await responce.json();
        showRecipes(data);
    } catch (error) {
        
    }
}

function showRecipes(data) {
    let mainElement = document.getElementsByTagName('MAIN')[0];
    let loadingElement = document.querySelector('body > main > p');
    loadingElement.remove();

    for (const key in data.details) {
        console.log(data.details[key]);
        let articleElement = document.createElement('article');
        articleElement.classList.add('preview');
        articleElement.id = data.details[key]._id;
    
        let titleDivElement = document.createElement('div');
        titleDivElement.classList.add('title');

        let titleH2Element = document.createElement('h2');
        titleH2Element.textContent = data.details[key].name;

        titleDivElement.appendChild(titleH2Element);

        let imageDivElement = document.createElement('div');
        imageDivElement.classList.add('small');

        let imgElement = document.createElement('img');
        imgElement.src = data.details[key].img;

        imageDivElement.appendChild(imgElement);

        articleElement.appendChild(titleDivElement);
        articleElement.appendChild(imageDivElement);

        mainElement.appendChild(articleElement);
    }

    mainElement.addEventListener('click', getRecipeDetails);
}

async function getRecipeDetails(e) {
    e.preventDefault();

    if(e.target.tagName != 'ARTICLE') {
        return;
    }

    let id = e.target.id;

    try {
        const responce = await fetch(`http://localhost:3030/jsonstore/cookbook/details/${id}`);
        const data = await responce.json();
        console.log(data);
        showRecipeDetails(data);
    } catch (error) {
        
    }
}

function showRecipeDetails(data) {

    let recipeElement = document.getElementById(data._id);
    let mainElement = document.getElementsByTagName('MAIN')[0];


    console.log('main element', mainElement);
    console.log('recipe element', recipeElement);

    let recipeDetailsArticleElement = document.createElement('article');
    console.log('recipeDetailsArticleElement', recipeDetailsArticleElement);

    
    let titleH2Element = document.createElement('h2');
    titleH2Element.textContent = data.name;
    console.log('titleH2Element', titleH2Element);

    let bandDivElement = document.createElement('div');
    bandDivElement.classList.add('band');
    console.log('bandDivElement', bandDivElement);

    let thumbDivElement = document.createElement('div');
    thumbDivElement.classList.add('thumb');
    console.log('thumbDivElement', thumbDivElement);

    let imgElement = document.createElement('img');
    imgElement.src = data.img;

    let ingredientsDivElement = document.createElement('div');
    ingredientsDivElement.classList.add('ingredients');
    console.log('ingredientsDivElement', ingredientsDivElement);

    let ingredientsUlElement = document.createElement('ul');
    ingredientsUlElement.id = 'ingredientsUlElement';
    console.log('ingredientsUlElement', ingredientsUlElement);

    let ingredientsHeader = document.createElement('h3');
    ingredientsHeader.textContent = 'Ingredients:';

    let descriptionDivElement = document.createElement('div');
    descriptionDivElement.classList.add('description');
    console.log('descriptionDivElement', descriptionDivElement);

    let descriptionHeader = document.createElement('h3');
    descriptionHeader.textContent = 'Preparation:';

    recipeDetailsArticleElement.appendChild(titleH2Element);
    
    thumbDivElement.appendChild(imgElement);
    console.log('112 row');
    ingredientsHeader.appendChild(ingredientsUlElement);
    console.log('114 row');
    descriptionDivElement.appendChild(descriptionHeader);

    bandDivElement.appendChild(thumbDivElement);
    bandDivElement.appendChild(ingredientsDivElement);

    fillIngredients(ingredientsUlElement, data);
    fillDescritions(descriptionDivElement, data);

    ingredientsDivElement.appendChild(ingredientsUlElement);

    recipeDetailsArticleElement.appendChild(bandDivElement);
    recipeDetailsArticleElement.appendChild(descriptionDivElement);

    // mainElement.appendChild(recipeDetailsArticleElement);
    mainElement.replaceChild(recipeDetailsArticleElement, recipeElement);
    console.log('127 row');
    console.log('recipeDetailsArticleElement', recipeDetailsArticleElement);
}

function fillIngredients(ingredientsUlElement, data) {
    data.ingredients.forEach(i => {
        let liElement = document.createElement('li');
        liElement.textContent = i;

        ingredientsUlElement.appendChild(liElement);
    });
}

function fillDescritions(descriptionDivElement, data) {
    data.steps.forEach(d => {
        let pElement = document.createElement('p');
        pElement.textContent = d;
        descriptionDivElement.appendChild(pElement);
    });
}