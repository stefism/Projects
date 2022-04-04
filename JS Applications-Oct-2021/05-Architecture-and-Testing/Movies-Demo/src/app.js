import { logout } from './api/data.js';
import { showCatalogPage } from './catalog.js';
import { showAboutPage, showHomePage } from './home.js';
import { showLoginPage } from './login.js';
import { showRegisterPage } from './register.js';
import { showSection } from './dom.js'

document.getElementById('logoutBtn').addEventListener('click', onLogout);
document.querySelector('nav').addEventListener('click', onNavigate); //Този евент няма да се изпълни, защото във функцията onLogout сме сложили e.stopImmediatePropagation().

const views = {
    'home': showHomePage,
    'catalog': showCatalogPage,
    'about': showAboutPage,
    'login': showLoginPage,
    'register': showRegisterPage
}

const links = {
    'homeBtn': 'home',
    'catalogBtn': 'catalog',
    'aboutBtn': 'about',
    'loginBtn': 'login',
    'registerBtn': 'register'
};

updateUserNav();

const context = {
    updateUserNav,
    goTo,
    showSection
}

goTo('home');

function onNavigate(e) {
    updateUserNav();
    // Тука нямаме peventDefault защото в thml страницата на линка имаме <a href="javascript:void(0)", което не презарежда страницата.
    if(e.target.tagName == 'A') {
        const name = links[e.target.id];

        if(name) {
            goTo(name);
        }
    }
}

function goTo(name, ...params) {
    const view = views[name];

    if(typeof view == 'function') {
        view(context, ...params);
    }
}

export function updateUserNav() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if(userData != null) {
        document.getElementById('loginBtn').style.display = 'none';
        document.getElementById('registerBtn').style.display = 'none';
        document.getElementById('logoutBtn').style.display = '';
    } else {
        document.getElementById('loginBtn').style.display = '';
        document.getElementById('registerBtn').style.display = '';
        document.getElementById('logoutBtn').style.display = 'none';
    }
}

async function onLogout(e) {
    e.stopImmediatePropagation(); //Тази функция на евента спира изпълнението на евент лисенерите, след този на който е закачена. Ако искаме някой евент да не се изпълнява когато този се изпълние, трябва горе в кода, да го сложим след този. Използва се когато се очаква, ако се изпълни този евент, нещо в друг евент да гръмне. В случая, горе в кода, понеже евента, който изпълнява функцият onNavigate е закачен след този, когато този се изпълни, onNavigate няма да се изпълни. Сътветно ако този не се изпълни, тоест ако нямаме излизане на потребител, onNavigate функцията от евента, който е закачен след този, ще се изпълни.

    await logout();
    
    updateUserNav();
    goTo('home');
}