import { login } from '../api/data.js';
import { html } from '../lib.js';
import { getAllFormEntriesAsObject } from '../util.js';

const loginTemplate = (onLogin) => html`
<div class="narrow drop">
    <h1>Login</h1>
    <form @submit = ${onLogin}>
        <label><span>Email</span> <input type="text" , name="email"></label>
        <label><span>Password</span> <input type="password" , name="password"></label>
        <div class="center">
            <input class="action" type="submit" , value="Sign In">
        </div>
    </form>
</div>
`;

export function loginPage(context) {
    context.render(loginTemplate((e) => onLogin(e, context.page)));
}

async function onLogin(e, page) {
    e.preventDefault();

    const formEntries = getAllFormEntriesAsObject(e.target);
    await login(formEntries.email, formEntries.password);

    page.redirect('/Forum/index.html');
}