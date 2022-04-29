import { html, render } from '../../node_modules/lit-html/lit-html.js';

const host = 'http://localhost:3030/jsonstore/collections';

async function request(url, method = 'get', data) {
    const options = {
        method,
        headers: {}
    };

    if(data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const responce = await fetch(host + url, options);

    if(responce.ok = false) {
        const error = await responce.json();
        alert(error.message);
        throw new Error(error.message);
    }

    return responce.json();
}

async function getBooks() {
    return request('/books');
}

async function getById(id) {
    return request('/books' + id);
}

async function createBook(book) {
    return request('/books', 'post', book);
}

async function updateBook(id, book) {
    return request('/books/' + id, 'put', book);
}

async function deleteBook(id) {
    return request('/books/' + id, 'delete');
}

export { html, render, request, getBooks, createBook, updateBook, deleteBook, getById };