import { createIdea } from "../api/data.js";

const section = document.getElementById('createPage');
section.remove();

let currContext = null;

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export async function showCreatePage(context) {
    currContext = context;
    currContext.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const title = formData.get('title').trim();
    const description = formData.get('description').trim();
    const img = formData.get('imageURL').trim();

    if(title.length < 6) {
        return alert('Title must be at 6 characters long');
    }

    if(description.length < 10) {
        return alert('Description must be at 10 characters long');
    }

    if(img.length < 5) {
        return alert('Image URL must be at 5 characters long');
    }

    createIdea({ title, description, img });
    form.reset();
    currContext.goTo('catalog');
}