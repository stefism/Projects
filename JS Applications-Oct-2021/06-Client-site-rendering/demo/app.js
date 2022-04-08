import { renderTemplate } from './enjine.js';

async function start() {
    const data = await(await fetch('./data.json')).json();
    const template = await(await fetch('./article.html')).text();
    
    // const result = renderTemplate(template, data[0]);
    // console.log(result);

    const main = document.querySelector('main');
    main.innerHTML = data.map(dataElement => renderTemplate(template, dataElement)).join('');
    //Понеже renderTemplate връща масив от стрингове и като подадем масив на innerHTML той ще викне вътрешно .toString() и това ще ни го изкара на екрана със запетайки между отделните елементи. За да нямаме запетайки, трябва да го джойнем масива по празен елемент и готово.
}

start();