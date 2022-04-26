import { html, render } from '../node_modules/lit-html/lit-html.js';

async function getData() {
    const responce = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
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

    dataArray.push({text: text, _id: text});
    form.reset();

    const responce = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text: text, _id: text })
    });

    console.log(dataArray);

    onRender();
}

async function postDataOnServer() {
    const responce = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    const data = await responce.json();

    return data;
}

function onRender() {
    render(dataArray.map(template), selectElement);
}

onRender();