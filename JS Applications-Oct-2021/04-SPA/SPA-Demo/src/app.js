import { showCatalogPage } from './catalog.js';
import { showAboutPage, showHomePage } from './home.js';
import { showLoginPage } from './login.js';
import { showRegisterPage } from './register.js';

document.getElementById('logoutBtn').addEventListener('click', onLogout);
document.querySelector('nav').addEventListener('click', onNavigate); //Този евент няма да се изпълни, защото във функцията onLogout сме сложили e.stopImmediatePropagation().

const sections = {
    'homeBtn': showHomePage,
    'catalogBtn': showCatalogPage,
    'aboutBtn': showAboutPage,
    'loginBtn': showLoginPage,
    'registerBtn': showRegisterPage
};

updateUserNav();
showHomePage();

function onNavigate(e) {
    updateUserNav();

    if(e.target.tagName == 'A') {
        const view = sections[e.target.id];

        if(typeof view == 'function') {
            // Тука нямаме peventDefault защото в thml страницата на линка имаме <a href="javascript:void(0)", което не презарежда страницата.
            view();
        }
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

    const { token } = JSON.parse(sessionStorage.getItem('userData')); //{ token } - Деструктурираме обекта userData и взимаме от неко само token.
    const response = await fetch('http://localhost:3030/users/logout', {
        headers: {
            'X-Authorization': token
        }
    });

    sessionStorage.removeItem('userData');
    
    updateUserNav();
    showHomePage();
}