import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/collections/books/';

const tableSection = document.getElementById('table');

const addForm = document.getElementById('add-form');
addForm.addEventListener('submit', addBook);

const editForm = document.getElementById('edit-form');
editForm.addEventListener('submit', saveEditedBook);

async function getData() {
    const responce = await fetch(url);
    const data = await responce.json();
    
    return Object.entries(data);
}

const allBooks = await getData();

const template = (books) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        ${books.map(b => html`
            <tr>
                <td>${b[1].author}</td>
                <td>${b[1].title}</td>
                <td>
                    <button @click = ${(event) => onEdit(event, b[0])}>Edit</button>
                    <button @click = ${(event) => onDelete(event, b[0])}>Delete</button>
                </td>
            </tr>
        `)}
    </tbody>
</table>
`;

let editBookId = '';

async function onEdit(event, bookId) {
    event.preventDefault();

    addForm.style.display = 'none';
    editForm.style.display = 'block';

    const responce = await fetch(url + bookId);
    const book = await responce.json();

    editBookId = bookId;

    editForm.querySelector('[name="title"]').value = book.title;
    editForm.querySelector('[name="author"]').value = book.author;
}

async function saveEditedBook(e) {
    e.preventDefault();

    addForm.style.display = 'block';
    editForm.style.display = 'none';

    const formData = new FormData(editForm);

    const bookTitle = formData.get('title');
    const bookAuthor = formData.get('author');

    if(!bookTitle || !bookAuthor) {
        return;
    }

    await fetch(url + editBookId, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({author: bookAuthor, title: bookTitle})
    });

    const bookIndex = allBooks.findIndex(b => b[0] == editBookId);
    allBooks[bookIndex][1].author = bookAuthor;
    allBooks[bookIndex][1].title = bookTitle;

    onRender();
}

async function onDelete(event, bookId) {
    event.preventDefault();

    if(confirm('Do you want to delete this book?')) {
        await fetch(url + bookId, {
            method: 'delete'
        });
    
        const bookIndex = allBooks.findIndex(b => b[0] == bookId);
        allBooks.splice(bookIndex, 1);
    
        onRender();
    }
}

async function addBook(ev) {
    ev.preventDefault();

    const formData = new FormData(addForm);

    const bookTitle = formData.get('title');
    const bookAuthor = formData.get('author');

    if(!bookTitle || !bookAuthor) {
        return;
    }

    const responce = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({author: bookAuthor, title: bookTitle})
    });

    const bookData = await responce.json();
    const newBook = [bookData._id, { author: bookData.author, title: bookData.title }];

    allBooks.push(newBook);
    addForm.reset();

    onRender();
}

function onRender() {
    render(template(allBooks), tableSection);
}

onRender();