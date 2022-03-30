import { createDomElement, getDataFromSessionStorage, request, showLoading, showView } from './dom.js';

const section = document.getElementById('movie-details');
// const userData = getDataFromSessionStorage('userData');
section.remove();

export function showDetails(movieId) {
    showView(section);
    getMovie(movieId);
}

async function getMovie(id) {
    section.replaceChildren(showLoading());

    const requests = [
        fetch(`http://localhost:3030/data/movies/${id}`),
        fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`)
    ];

    const userData = getDataFromSessionStorage('userData');

    if (userData != null) {
        requests.push(fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userData.id}%22`));
    }

    const [movieresponse, likesresponse, hasLikedresponse] = await Promise.all(requests);

    const [movieData, likesData, hasLikedData] = await Promise.all([
        movieresponse.json(),
        likesresponse.json(),
        hasLikedresponse && hasLikedresponse.json() //Тука мега яко, тернарен оператор в елемент от масив. Понеже има вероятност hasLikedresponse да е undefined, понеже горе се вика при условие. И за да не фърли грешка, тука казваме, че само ако не е undefined hasLikedresponse, тогава викаме hasLikedresponse.json().
    ]);

    section.replaceChildren(createDetails(movieData, likesData, hasLikedData));
}

function createDetails(movie, likes, hasLiked) {
    const controls = createDomElement('div', { className: 'col-md-4 text-center' },
        createDomElement('h3', { className: 'my-3' }, 'Movie Description'),
        createDomElement('p', {}, movie.description)
    );

    const userData = getDataFromSessionStorage('userData');

    if (userData != null) {
        if (userData.id == movie._ownerId) {
            controls.appendChild(createDomElement('a', { className: 'btn btn-danger', href: '#' }, 'Delete'));
            controls.appendChild(createDomElement('a', { className: 'btn btn-warning', href: '#' }, 'Edit'));
        } else {
            if (hasLiked.length > 0) {
                controls.appendChild(createDomElement('a', { className: 'btn btn-primary', href: '#', onClick: onUnlike }, 'Unlike'));
            } else {
                controls.appendChild(createDomElement('a', { className: 'btn btn-primary', href: '#', onClick: onLike }, 'Like'));
            }
        }
    }

    controls.appendChild(createDomElement('span', { className: 'enrolled-span' }, `Liked ${likes}`));

    const element = createDomElement('div', { className: 'container' },
        createDomElement('div', { className: 'row bg-light text-dark' },
            createDomElement('h1', {}, `Movie title: ${movie.title}`),
            createDomElement('div', { className: 'col-md-8'},
                createDomElement('img', { className: 'img-thumbnail', src: movie.img, alt: 'Movie'})
            ),
            controls
        )
    );

    return element;

    async function onLike() {
        await request('http://localhost:3030/data/likes', {
            method: 'post',
            headers: {
                'X-Authorization': userData.token
            },
            body: JSON.stringify({movieId: movie._id})
        });

        showDetails(movie._id);
    }

    async function onUnlike() {
        const likeId = hasLiked[0]._id;

        await request('http://localhost:3030/data/likes/' + likeId, {
            method: 'delete',
            headers: {
                'X-Authorization': userData.token
            }
        });

        showDetails(movie._id);
    }
}