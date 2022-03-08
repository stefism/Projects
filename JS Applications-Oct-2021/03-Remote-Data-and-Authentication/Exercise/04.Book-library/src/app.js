const loadBooksBtn = document.getElementById('loadBooks');
const tableBody = document.querySelector('tbody');
tableBody.addEventListener('click', bookActions);

const submitBookForm = document.getElementById('submitForm');
submitBookForm.addEventListener('submit', showNewCreatedBookToDom);

const editForm = document.getElementById('editForm');
editForm.addEventListener('submit', onSaveClicked);

loadBooksBtn.addEventListener('click', showBooksInDomTable);

const url = 'http://localhost:3030/jsonstore/collections/books/';

let selectedBookId = '';
let tableTitle = '';
let tableAuthor = '';

async function loadAllBooks() {
    const responce = await fetch(url);
    const result = await responce.json();

    return Object.entries(result);
}

async function onSaveClicked(e) {
    e.preventDefault();

    const formData = new FormData(editForm);

    let title = formData.get('title');
    let author = formData.get('author');

    await editBook(selectedBookId, title, author);

    tableTitle.textContent = title;
    tableAuthor.textContent = author;

    submitBookForm.style.display = 'block';
    editForm.style.display = 'none';
}

async function showBooksInDomTable() {
    tableBody.replaceChildren();

    let books = await loadAllBooks();
    books = books.map(createBookDomElement);

    books.forEach(b => tableBody.appendChild(b));
}

async function bookActions(e) {
    e.preventDefault();

    if (e.target.textContent == 'Delete') {
        deleteBookById(e.target.id);
        e.target.parentNode.parentNode.remove();
    } else if (e.target.textContent == 'Edit') {
        submitBookForm.style.display = 'none';
        editForm.style.display = 'block';

        selectedBookId = e.target.id;
        tableTitle = e.target.parentNode.parentNode.querySelector('.book-title');
        tableAuthor = e.target.parentNode.parentNode.querySelector('.book-author');

        editForm.querySelectorAll('input')[0].value = tableTitle.textContent;
        editForm.querySelectorAll('input')[1].value = tableAuthor.textContent;
    }
}

async function deleteBookById(bookId) {
    let deleteUrl = url + bookId;

    await fetch(deleteUrl, {
        method: 'delete'
    });
}

async function editBook(bookId, title, author) {
    let editUrl = url + bookId;

    await fetch(editUrl, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, author })
    });
}

async function showNewCreatedBookToDom(e) {
    e.preventDefault();

    let bookResult = await saveNewBookToServer();

    if(!bookResult) {
        alert('Please fill the all fields with data.');
        return;
    }

    let newBook = createBookDomElement(bookResult);

    let buttons = newBook.querySelectorAll('button');
    buttons[0].id = bookResult._id;
    buttons[1].id = bookResult._id;

    tableBody.appendChild(newBook);
}

async function saveNewBookToServer() {
    const formData = new FormData(submitBookForm);

    let author = formData.get('author');
    let title = formData.get('title');

    if (author == '' || title == '') {
        return false;
    }

    const responce = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ author, title })
    });

    submitBookForm.reset();

    return await responce.json();
}

function createBookDomElement(book) {
    let tableRow = document.createElement('tr');

    let tableDataTitle = document.createElement('td');
    tableDataTitle.classList.add('book-title');

    let tableDataAuthor = document.createElement('td');
    tableDataAuthor.classList.add('book-author');

    let tableDataAction = document.createElement('td');

    let editBtn = document.createElement('button');
    editBtn.textContent = 'Edit';

    let deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';

    if (book.length == 2) {
        tableDataTitle.textContent = book[1].title;
        tableDataAuthor.textContent = book[1].author;

        editBtn.id = book[0];
        deleteBtn.id = book[0];
    } else {
        tableDataTitle.textContent = book.title;
        tableDataAuthor.textContent = book.author;
    }

    tableDataAction.appendChild(editBtn);
    tableDataAction.appendChild(deleteBtn);

    tableRow.appendChild(tableDataTitle);
    tableRow.appendChild(tableDataAuthor);
    tableRow.appendChild(tableDataAction);

    return tableRow;
}