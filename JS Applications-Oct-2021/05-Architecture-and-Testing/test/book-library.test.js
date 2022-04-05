const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0":{
        "author":"J.K.Rowling",
        "title":"Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1":{
        "author":"Svetlin Nakov",
        "title":"C# Fundamentals"
    }
};

const url = 'http://127.0.0.1:5501/Exercise/02.Book-Library/index.html';

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    };
}

describe('Tests', async function() {
    //Тук пишем async function(), а не ароу функция, заради this.timeout(5000). Единствения начин да имаме контекст this е ако това е обикновена функция. Ароу функцията пази контекста на мястото където е създадена, а не на мястото, където се изпълнява и съответно mocha няма как да въведе вътре в нея своя контекст.
    this.timeout(5000);

    let page, browser;

    before(async () => { //before - функция, която се изпълнява преди всички тестове.
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => { //beforeEach се изпълнява преди всеки тест.
        page = await browser.newPage();
    });

    this.afterEach(async () => {
        page = await browser.close();
    });

    it('Load and display all books', async () => {
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData));
        });
        //Тази функция ще слуша и когато се изпрати заявка до горния адрес, заявката няма да отиде до сървъра, а функцията ще върне респонс с мокнатите данни.
        //Използваме глоб патерн - хвани заявка към даден път, обаче няма значение на кой хост нейм се намира. ** означава - хващай всички хостове.
        //'Access-Control-Allow-Origin': '*' - пише се за да няма CORS грешка от браузъра.

        await page.goto(url);
        await page.click('text=Load all books');
        await page.waitForSelector('text=Harry Potter');

        const rows = await page.$$eval('tr', (rows) => rows.map(r => r.textContent.trim())); //rows в случая е масив.
        //$$eval() дава възможност за изпълняване на функция в контекста (конзолата) на браузъра. Това ни позволява, примерно да селектираме каквото си искаме и да го превърнем след това в масив. Първо подаваме селектор и след това фукцията, която ще се изпълни върху селектираните елементи.
        expect(rows[1]).to.contains('Harry Potter');
        expect(rows[1]).to.contains('Rowling');
        expect(rows[2]).to.contains('C# Fundamentals');
        expect(rows[2]).to.contains('Nakov');
    });

    it.only('Cteate new book', async () => {
        await page.goto(url);

        await page.fill('form#createForm >> input[name="title"]', 'Test book title');
        await page.fill('form#createForm >> input[name="author"]', 'Author book test');
        
        const [request] = await Promise.all([
            page.waitForRequest(request => request.method() == 'POST'),
            page.click('form#createForm >> text=Submit')
        ]); //Тук има особеност това са блокиращи операции и ако първо цъкнем и после регистрираме слушателя (без да са вкарани двете заявки в Promise.all), браузъра ще е изпратил заявката, преди ние да сме регистрирали слушателя. И затова тези две заявки трябва да се извършат паралелно. Ако направим обратното, браузъра никога няма да клике, защото ние му казваме - изчакай заявката и като дойде заявката, кликни - обаче той пък ако не кликне, заявката няма да тръгне никога.
        
        const data = JSON.parse(request.postData());

        expect(data.title).to.equal('Test book title');
        expect(data.author).to.equal('Author book test');
    });
})