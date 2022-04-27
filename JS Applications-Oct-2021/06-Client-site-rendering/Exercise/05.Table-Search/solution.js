import { html, render } from '../node_modules/lit-html/lit-html.js';

const tableBody = document.querySelector('.container tbody');
const searchField = document.getElementById('searchField');

document.getElementById('searchBtn').addEventListener('click', onSearch);

async function getData() {
    const responce = await fetch('http://localhost:3030/jsonstore/advanced/table');
    const data = await responce.json();

    return Object.values(data);
}

const template = (item) => html`
<tr class="${item.match ? 'select' : 'none'}">
    <td>${item.firstName} ${item.lastName}</td>
    <td>${item.email}</td>
    <td>${item.course}</td>
</tr>
`;

const data = await getData();

function onSearch() {
    const searchText = searchField.value.toLowerCase();

    if (searchText == '' || searchText == ' ') {
        return;
    }

    data.forEach(item => {
        item.match = false;

        for (const key in item) {
            if (typeof (item[key]) != 'boolean' && item[key].toLowerCase().includes(searchText)) {
                item.match = true;
                break;
            }
        }
    });

    searchField.value = '';

    onRender();
}

function onRender() {
    render(data.map(template), tableBody);
}

onRender();