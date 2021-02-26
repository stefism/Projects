import React, { Component } from 'react';

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: ''
        }

        this.change = this.change.bind(this)
    }

    change(event) {
        this.setState({
            [event.target.name]: event.target.value
        })
    }

    render() {
        return (
            <div>
                <h2>Please login to use the site :)</h2>
                <form>
                    <label>Username: </label>
                    <input type='text' name='username' 
                    onChange={event => this.change(event)}
                    value={this.state.username} />
                    
                    <label>Password: </label>
                    <input type='text' name='password' 
                    onChange={event => this.change(event)}
                    value={this.state.password} />

                    <button>Login</button>
                </form>
            </div>
        )
    }
}

export default Login