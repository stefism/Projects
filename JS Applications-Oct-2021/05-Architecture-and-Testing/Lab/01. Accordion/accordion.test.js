const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;

describe('E2E tests', async function() {
    this.timeout(5000); //Това трябва да се сложи задължително когато имаме асинхронни тестове, щото иначе теста гърми ето с тази грешка:
    //Error: Timeout of 2000ms exceeded. For async tests and hooks, ensure "done()" is called; if returning a Promise, ensure it resolves. (D:\Stefan\SoftUni\Projects\JS Applications-Oct-2021\05-Architecture-and-Testing\test\test-accordion.js)

    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Initial load', async () => {
        await page.goto('http://127.0.0.1:5501/Lab/01.%20Accordion/index.html');
        // await page.screenshot({ path: 'page.png'});
        await page.waitForSelector('.accordion'); //Правим това за да може браузъра да изчака да се появи този елемент на страницата и тогава да изпълни теста. Може да има забавяне на отговора от сървъра и ако го нямаме това, теста пак ще даде грешка.

        const content = await page.textContent('#main');
        expect(content).to.contain('Scalable Vector Graphics');
        expect(content).to.contain('Open standard');
        expect(content).to.contain('Unix');
        expect(content).to.contain('ALGOL');
    });

    it('More button works', async () => {
        //Ако имаме много тестове и в един момент искаме да изпълним само някои от тях, можем да сложим it.only и ще се изпълнят само тези тестове, които имат only.
        await page.goto('http://127.0.0.1:5501/Lab/01.%20Accordion/index.html');
        await page.waitForSelector('.accordion');

        await page.click('text=More'); //Това ще кликне на първото срещнато, което съдържа стринга.
        //Така написане е еквивалетно на containt и е case insensitive. Ще хване всичко, което съдържа More без значение от главни и малки букви.
        // await page.click('text="More"'); Така написано ще търси точно и само тази дума и ще има значение главните и малките букви.
        await page.waitForResponse(/articles\/details/i); // Трябва да изчакаме отговора от сървъра на съответния адрес на който кликването на бутона прави заявката. Понеже при кликването на бутона се прави заявка до адрес http://localhost:3030/jsonstore/advanced/articles/details/fdf00227-084f-48bc-a450-9242a0963f1f, като параметър на waitForResponce можем да подадем регекс и да му кажем да провери за част от адреса.
        const visible = await page.isVisible('.accordion p'); //Виждаме къде на страницата (в кой html таг) трябва да се визуализира съдържанието и проверяваме дали въпросното съдържание се е появило. Тук няма нужда преди този ред да пишем waitForSelector защото в този случай ще се изчака селектора да се появи и тогава ще се провери за съдържание.

        expect(visible).to.be.true;
    });

    it.only('Less button works', async () => {
        await page.goto('http://127.0.0.1:5501/Lab/01.%20Accordion/index.html');
        await page.waitForSelector('.accordion');

        await page.click('text=More');
        await page.waitForResponse(/articles\/details/i);

        await page.waitForSelector('.accordion p', { state: 'visible' });

        await page.click('text=Less');

        const visible = await page.isVisible('.accordion p');

        expect(visible).to.be.false;
    });

    it('Form input', async () => {
        await page.goto('http://127.0.0.1:5501/Lab/01.%20Accordion/index.html');
        await page.fill('[name="email"]', 'Peter');
        await page.waitForTimeout(60000);
    });
});