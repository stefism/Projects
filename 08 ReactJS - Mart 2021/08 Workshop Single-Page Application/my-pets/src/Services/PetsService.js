export const getAll = (category = '') => {
    let url = 'http://localhost:5000/pets';
    url += (category && category != 'all') ? `?category=${category}` : ''; //Ако има нещо в category, ще долепи към url ?category=${category}. Ако няма, ще остави празен стринг.

    return fetch(url)
        .then(res => res.json())
        .catch(error => console.log(error));
}