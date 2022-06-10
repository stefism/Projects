import { login } from '../api/user-service.js';
import { html } from '../lib.js';
import { createSubmitHandler } from '../util.js';
import { field } from './common.js';

const loginTemplate = (onSubmit, errors, data) => html`
<section id="login">
    <article>
        <h2>Login</h2>
        <form @submit=${onSubmit} id="loginForm">
            ${errors ? html`<p class="error">${errors.message}</p>` : null}
            
            ${field({label: 'Username', name: 'username', value: data.username, error: errors.username})}
            ${field({label: 'Password', name: 'password', type: 'password', error: errors.password})}
            <input type="submit" value="Login">
        </form>
    </article>
</section>
`;

export function loginPage(context) {
    update();

    function update(errors = {}, data = {}) {
        context.render(loginTemplate(createSubmitHandler(onSubmit, 'username', 'password'), errors, data));
    }
    
    async function onSubmit(data, event) {
        try {
            if(data.username == '' || data.password == '') {
                throw {
                    message: 'Please fill all fields.',
                    username: true,
                    password: true
                };
            }
            // Тук може да деструкторираме username и password и да напишем горе onSubmit({username, password}) и по-долу да ползваме направо тях.
    
            await login(data.username, data.password);
            event.target.reset();
            
            context.updateSession();
            context.updateUserNav();
            context.page.redirect('/catalog');
        } catch (error) {
            update(error, data.username);
        }
    }
}