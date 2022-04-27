import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

async function getData() {
    const responce = await fetch(url);
    const data = await responce.json();

    return data;
}

const data = await getData();
const dataArray = Object.values(data);
console.log(dataArray);

const template = (element) => html`<option>${element.text}</option>`;

const selectElement = document.getElementById('menu');
const form = document.getElementById('testForm');
form.addEventListener('submit', onSubmit);

async function onSubmit(e) {
    e.preventDefault();
    
    const formData = new FormData(form);
    const text = formData.get('itemText');

    if (text == '' || text == ' ') {
        return;
    }

    dataArray.push({text: text, _id: text});
    form.reset();

    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text: text, _id: text })
    });

    console.log(dataArray);

    onRender();
}

function onRender() {
    render(dataArray.map(template), selectElement);
}

onRender();