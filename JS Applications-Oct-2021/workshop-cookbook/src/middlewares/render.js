import { render } from '../lib.js';
import { getUserData } from '../util.js';

export default function initialize() {
    const root = document.querySelector('main');
    updateUserNav();

    return function (context, next) {
        context.render = boundRender;
        context.updateUserNav = updateUserNav;
    
        next();
    };

    function updateUserNav() {
        const userData = getUserData();
    
        if(userData) {
            document.getElementById('user').style.display = 'inline-block';
            document.getElementById('guest').style.display = 'none';
        } else {
            document.getElementById('user').style.display = 'none';
            document.getElementById('guest').style.display = 'inline-block';
        }
    }

    function boundRender(content) {
        render(content, root);
    }
}