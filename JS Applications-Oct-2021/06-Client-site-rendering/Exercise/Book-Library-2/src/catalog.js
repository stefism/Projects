import { getBooks, html, until } from './utility.js';

const catalogTemplate = (booksPromise) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        ${until(booksPromise, html`
        <tr>
            <td colSpan="3">Loading&hellip;</td>
        </tr>`)}
        <!-- until приема като първи параметър промис, който като се резолвне ще върне редовете (в случая ще е масива с книгите), а като втори параметър приема нещо дето да се визуализира, докато данните се появят. -->
    </tbody>
</table>
`;

const bookRowTemplate = (book, onEdit) => html`
<tr>
   <td>${book.title}</td>
   <td>${book.author}</td>
   <td>
       <button @click=${onEdit}>Edit</button>
       <button>Delete</button>
   </td>
</tr>
`;

export function showCatalog(context) {
    return catalogTemplate(loadBooks(context));
}

async function loadBooks(context) {
    const data = await getBooks();

    const books = Object.entries(data).map(([k, v]) => Object.assign(v, { _id: k}));

    return Object.values(books).map(book => bookRowTemplate(book, () => toggleEditor(book, context))); //() => toggleEditor - няма как да му подадем параметрите ако не е така. (Опаковаща функция)
}

function toggleEditor(book, context) {
    context.book = book;
    context.update();
}