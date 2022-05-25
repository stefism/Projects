import { register } from '../api/data.js';
import { input } from '../common/input.js';
import { html } from '../lib.js';
import { getAllFormEntriesAsObject } from '../util.js';

const registerTemplate = (onRegister, errorMsg, errors, values) => html`
<div class="narrow drop">
    <h1>Register</h1>
    <form @submit=${onRegister}>
        ${errorMsg ? html`<p class="error-msg">${errorMsg}</p>` : null}
        ${input('Email', 'text', 'email', values.email, errors.email)}
        ${input('Display Name', 'text', 'username', values.username, errors.username)}
        ${input('Password', 'password', 'password', values.password, errors.password)}
        ${input('Repeat password', 'password', 'rePass', values.rePass, errors.rePass)}
        <div class="center">
            <input class="action" type="submit" , value="Register">
        </div>
    </form>
</div>
`;

export function registerPage(context) {
    context.render(registerTemplate((e) => onRegister(e, context), null, {}, {}));
}

async function onRegister(e, context) {
    e.preventDefault();

    const formEntries = getAllFormEntriesAsObject(e.target);

    try {
        const missing = Object.entries(formEntries).filter(([k, v]) => v == '');
        if(missing.length > 0) {
            const errors = missing.reduce((a, [k]) => Object.assign(a, { [k]: true }), {});
            throw {
                error: new Error('All fields are required.'),
                errors
            };
        }

        if(formEntries.password != formEntries.rePass) {
            throw {
                error: new Error('Passwords is not match.'),
                errors: {
                    password: true,
                    rePass: true
                }
            };
        }

        await register(formEntries.email, formEntries.password);
        context.page.redirect('/Forum/index.html');
    } catch (error) {
        const message = error.message || error.error.message;
        context.render(registerTemplate((e) => onRegister(e, context), message, error.errors, formEntries));
    }
}