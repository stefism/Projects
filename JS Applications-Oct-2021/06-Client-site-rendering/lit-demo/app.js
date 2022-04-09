import { render } from 'https://unpkg.com/lit-html?module';
import articleTemplate from './templates/article.js';

async function start() {
    const data = await(await fetch('./data.json')).json();
    const main = document.querySelector('main');

    function onRender() {
        const result = data.map(article => articleTemplate(onSubmit.bind(null, article), article));
        render(result, main);
    }
    
    onRender();

    function onSubmit(article, event) {
        event.preventDefault();
    
        const formData = new FormData(event.target);
        const content = formData.get('comment');
        article.comments.push({ content });

        onRender();
    }
}

start();