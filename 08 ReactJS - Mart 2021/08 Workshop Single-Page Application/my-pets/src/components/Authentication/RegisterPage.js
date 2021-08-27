import { useState } from "react";
import { auth } from "../../Config/firebase";

const RegisterPage = ({ history }) => {
    const [isPassMatch, setIsPassMatch] = useState(true);
    const [errMsg, setErrMsg] = useState('');

    const onRegisterSubmitHandler = (e) => {
        e.preventDefault();

        const username = e.target.username.value;
        const password = e.target.password.value;
        const repeadPassword = e.target.repeadPassword.value;

        if(password == repeadPassword) {
           auth.createUserWithEmailAndPassword(username, password)
               .then(userCredential => {
               history.push('/');
           }).catch((error) => {
                setIsPassMatch(false);
                setErrMsg(error.message);
           });
        } else {
            setIsPassMatch(false);
            setErrMsg('Passwords is not match!');
        }
    }

    return (
        <section className="register">
                <form onSubmit={onRegisterSubmitHandler}>
                    <fieldset>
                        <legend>Register</legend>
                        <p className="field">
                            {!isPassMatch &&
                            <label style={{color: "red"}} htmlFor="">{errMsg}</label>
                            }
                            <label htmlFor="username">Email</label>
                            <span className="input">
                                <input type="text" name="username" id="username" placeholder="Email" />
                                <span className="actions"></span>
                                <i className="fas fa-user"></i>
                            </span>
                        </p>
                        <p className="field">
                            <label htmlFor="password">Password</label>
                            <span className="input">
                                <input onClick={() => setIsPassMatch(true)} type="password" name="password" id="password" placeholder="Password" />
                                <span className="actions"></span>
                                <i className="fas fa-key"></i>
                            </span>
                        </p>
                        <p className="field">
                            <label htmlFor="repeadPassword">Repeat Password</label>
                            <span className="input">
                                <input type="password" name="repeadPassword" id="repeadPassword" placeholder="Repeat Password" />
                                <span className="actions"></span>
                                <i className="fas fa-key"></i>
                            </span>
                        </p>
                        <input className="button" type="submit" className="submit" value="Register" />
                    </fieldset>
                </form>
            </section>
    )
}

export default RegisterPage;