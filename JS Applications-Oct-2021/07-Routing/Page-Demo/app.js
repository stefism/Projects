import page from '//unpkg.com/page/page.mjs';

function homePage(context, next) {
    console.log(context);
    console.log(next);
    main.innerHTML = '<h2>Home Page</h2><p>Welcome to home page</p>';
}

function catalogPage() {
    main.innerHTML = '<h2>Catalog</h2><p>List of items</p>';
}

function detailsPage(context) {
    console.log(context);
    main.innerHTML = '<h2>Product</h2><p>Product details.</p>';
}

function aboutPage() {
    main.innerHTML = '<h2>About Us</h2><p>Contact: +359 8556-6544-963</p>';
}

const main = document.querySelector('main');

page('/home', homePage); //Изпълнявайки функцията, page и подава два параметъра. Единия е контекст, който е обект с параметри и състояния вътре в него, а другия е един кол бек, който можем да ползваме за да си направим мидълуер.
page('/catalog', catalogPage);
page('/catalog/:id', detailsPage); //:id - Хваща всичко след наклонената черта. Нещото след наклонената черта можем да го кръстим както си искаме.
page('/about', aboutPage);

page.redirect('/', '/home'); //Когато потребителя извика страницата без нищо все едно (/), ще го прати на /home.

page.start();