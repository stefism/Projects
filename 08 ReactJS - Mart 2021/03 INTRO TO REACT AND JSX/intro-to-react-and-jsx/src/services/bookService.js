function getAllBooks() {
    return fetch('http://localhost:3000/books')
    .then(response => response.json())
    .catch(error => console.log(error));
}

export default {getAllBooks};