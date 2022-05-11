import { html, until } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (moviePromise) => html`
<section id="movie-details">
    ${until(moviePromise, html`<p>Loading...</p>`)}
</section>
`;

const movieTemplate = (movie) => html`
<div class="row bg-light text-dark">
    
    <h1>Movie title: ${movie.title}</h1>

    <div class="col-md-8">
        <img class="img-thumbnail" src=${movie.img} alt="Movie">
    </div>

    <div class="col-md-4 text-center">

        <h3 class="my-3">Movie Description</h3>
        <p>${movie.description}</p>

        ${movie.isOwner
        ? html`
            <a class="btn btn-danger" href="#">Delete</a>
            <a class="btn btn-warning" href=${`/edit/${movie._id}`}>Edit</a>`
        : html`
            <a class="btn btn-primary" href="#">Like</a>`}
        <span class="enrolled-span">Liked 0</span>

    </div>
</div>
`;

export function detailsPage(ctx) {
    console.log('from details: ', ctx);
    ctx.render(detailsTemplate(loadMovie(ctx)));
}

async function loadMovie(ctx) {
    const movie = await ctx.moviePromise;

    const userData = getUserData();

    if(userData && userData.id == movie._ownerId) {
        movie.isOwner = true;
    }

    return movieTemplate(movie);
}