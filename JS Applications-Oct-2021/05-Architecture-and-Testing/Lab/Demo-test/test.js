// 1. npm init -y
// 2. npm install --save-dev playwright-chromium

const { chromium } = require('playwright-chromium');
(async () => {
    const browser = await chromium.launch();
    //Ако искаме да видим как се случват нещата, можем да подадем следното
    //chromium.launch({ headless: false, slowMo: 2000 }); slowMo: 2000 - чака определеното време между операциите, иначе ще го изпълни много бързо и няма да го видим.
    const page = await browser.newPage();
    await page.goto('https://google.com');
    await page.screenshot({ path: 'example.png'});
    await browser.close();
})();