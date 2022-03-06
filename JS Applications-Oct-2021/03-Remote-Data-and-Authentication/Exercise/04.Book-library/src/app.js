const loadBooksBtn = document.getElementById('loadBooks');
const tableBody = document.querySelector('tbody');

loadBooksBtn.addEventListener('click', loadAllBooks);

const url = 'http://localhost:3030/jsonstore/collections/books/';

async function loadAllBooks() {
    
}