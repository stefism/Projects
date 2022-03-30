import { createDomElement, showLoading, showView } from './dom.js';
import { showCreate } from './create.js';
import { showDetails } from './details.js';

let movieCache = null;
let lastLoaded = null;
const reloadedTime = 20000; //10000 милисекунди = 10 секунди.

const section = document.getElementById('home-page');
const catalog = section.querySelector('.card-deck.d-flex.justify-content-center'); //Тука нанизваме всичките класове с точки без интервал, защото интервала значи - вътре в това, намери отова, а при нас всичките класове са върху един и същи елемент.

section.querySelector('#createLink').addEventListener('click', (e) => {
    e.preventDefault();
    showCreate();
});

//Нодовете нямат функция getElementById, затова горе ако напишем section.getElementById('createLink') ще гръмне. Само с querySelector нодовете.

catalog.addEventListener('click', (e) => {
    e.preventDefault();

    if(e.target.tagName == 'BUTTON') {
        const id = e.target.dataset.id;
        showDetails(id);
    }
});

section.remove();

export function showHome() {
    showView(section);
    getMovies();
}

async function getMovies() {
    catalog.replaceChildren(showLoading());

    if(movieCache == null || Date.now() - lastLoaded > reloadedTime) {
        lastLoaded = Date.now(); //Date.now() показва текущата дата в js формат - като милисекунди.

        const response = await fetch('http://localhost:3030/data/movies');
        const data = await response.json();
        movieCache = data;
    }

    

    catalog.replaceChildren(...movieCache.map(createMovieCard)); //Понеже replaceChildren очаква поредица от елементи, а не масив, затова спредваме с ... това, което подаваме на функцията. В Случая ...data.map(createMovieCard).
}

function createMovieCard(movie) {
    const element = createDomElement('div', {className: 'card mb-4'});
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
       alt="Card image cap" width="400">
   <div class="card-body">
       <h4 class="card-title">${movie.title}</h4>
   </div>
   <div class="card-footer">
       <a href="#">
           <button data-id=${movie._id} type="button" class="btn btn-info">Details</button>
       </a>
   </div>`;

   return element;
}