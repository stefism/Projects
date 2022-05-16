import { register } from '../api/data.js';
import { html } from '../lib.js';

const registerTemplate = (onSubmit, errorMsg) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class=${'form-control' + (errorMsg ? ' is-invalid' : '')} id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class=${'form-control' + (errorMsg ? ' is-invalid' : '')} id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class=${'form-control' + (errorMsg ? ' is-invalid' : '')} id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>
`;



export function registerPage(context) {
    update();

    function update(errorMsg) {
        context.render(registerTemplate(onSubmit, errorMsg));
    }

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const rePass = formData.get('rePass').trim();

        if(email == '' || email == ' ' || password == '' || password == ' ') {
            update('Please fill correct all fields.');
            return;
        }

        if(password != rePass) {
            update('Passwords is don\'t match.');
            return;
        }

        try {
            await register(email, password);

            context.updateUserNav();
            context.page.redirect('/');
        } catch (error) {
            update(error);
        }
    }
}