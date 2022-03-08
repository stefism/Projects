const url = 'http://localhost:3030/jsonstore/collections/books/';
const tbody = document.querySelector('tbody');
tbody.addEventListener('click', onTableClick);

document.getElementById('loadBooks').addEventListener('click', loadBooks);
document.getElementById('submitForm').addEventListener('submit', onCreate);

function onTableClick(e) {
    if(e.target.className == 'delete') {
        onDelete(e.target);
    } else if(e.target.className == 'edit') {
        onEdit(e.target);
    }
}

async function onEdit(button) {
    const id = button.parentElement.dataset.id;
    const book = await loadBookById(id);
}

async function onDelete(button) {
    const id = button.parentElement.dataset.id;
    await deleteBook(id);
    button.parentElement.parentElement.remove();
}

async function onCreate(e) {
    e.preventDefault();
    const formData = new FormData(e.target);

    const author = formData.get('author');
    const title = formData.get('title');

    const book = await createBook({ author, title });
    tbody.appendChild(createRow(book._id, book));

    e.target.reset(); // Изчистваме полетата на формата.
}

async function loadBooks() {
    const books = await request(url);
    
    const result = Object.entries(books).map(([id, book]) => createRow(id, book));
    // console.log(result);
    // console.log(...result);
    tbody.replaceChildren(...result); // Деструктурираме го, защото очаква да получи поредица от елементи, а не масив.
}

async function loadBookById(id) {
    return await request(url + id);
}

function createRow(id, book) {
    const row = document.createElement('tr');
    row.innerHTML = `<td>${book.title}</td>
                     <td>${book.author}</td>
                     <td data-id=${id}><button class="edit">Edit</button><button class="delete">Delete</button>`;

    return row;
}

async function createBook(book) {
    const result = await request(url, {
        method: 'post',
        body: JSON.stringify(book)
    });

    return result;
}

async function updateBook(id, book) {
    const result = await request(url + id, {
        method: 'put',
        body: JSON.stringify(book)
    });

    return result;
}

async function deleteBook(id) {
    const result = await request(url + id, {
        method: 'delete'
    });

    return result;
}

async function request(url, options) {
    const responce = await fetch(url, options);

    if(options && options.body != undefined) {
        Object.assign(options, {
            headers: {
                'Content-Type': 'applications/json'
            }
        });
    }

    if(responce.ok != true) {
        const error = await responce.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = await responce.json();

    return data;
}