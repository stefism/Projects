import { html } from '../lib.js';

const registerTemplate = () => html`
<div class="narrow drop">
    <h1>Register</h1>
    <form>
        <label><span>Email</span> <input type="text" , name="email"></label>
        <label><span>Password</span> <input type="password" , name="password"></label>
        <label><span>Repeat Password</span> <input type="rePass" , name="password"></label>
        <div class="center">
            <input class="action" type="submit" , value="Register">
        </div>
    </form>
</div>
`;

export function registerPage(context) {
    context.render(registerTemplate());
}