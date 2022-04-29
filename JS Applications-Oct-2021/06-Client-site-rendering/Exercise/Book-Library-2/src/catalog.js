import { html } from './utility.js';

const catalogTemplate = (books) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Author 1</td>
            <td>Title 1</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr>
        <tr>
            <td>Author 2</td>
            <td>Title 2</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr>
    </tbody>
</table>
`;

export function showCatalog(context) {
    return catalogTemplate();
}