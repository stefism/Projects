const url = 'http://localhost:5000/pets';

const headers = {
    'Content-Type': 'application/json',
};

export const getAll = (category = '') => {
    let petsUrl = url + ((category && category != 'all') ? `?category=${category}` : ''); //Ако има нещо в category, ще долепи към url ?category=${category}. Ако няма, ще остави празен стринг.

    return fetch(petsUrl)
        .then(res => res.json())
        .catch(error => console.log(error));
}

export const getOne = (petId) => {
    return fetch(`${url}/${petId}`)
        .then(res => res.json())
        .catch(error => console.log(error));
}

export const create = (petName, description, imageURL, category) => {
    let pet = {
        name: petName,
        description,
        imageURL,
        category,
        likes: 0
    };

    return fetch(url, {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(pet)
    });
}

export const update = (petId, pet) => {
    return fetch(`${url}/${petId}`, {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(pet)
    });
}

export const updateLikes = (petId, likes) => {
    return fetch(`${url}/${petId}`, {
        method: 'PATCH', // PATCH e подобно на PUT но подава само пропертито, което искаме да променим.
        headers: headers,
        body: JSON.stringify({likes})
    }).then(res => res.json());
}