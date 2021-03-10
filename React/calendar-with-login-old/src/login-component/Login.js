import React, { Component } from 'react';
import axios from 'axios'

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: ''
        }

        this.change = this.change.bind(this);
        this.submit = this.submit.bind(this);
    }

    change(event) {
        this.setState({
            [event.target.name]: event.target.value
        })
    }

    submit(event) {
        event.preventDefault();
        axios.post('https://localhost:44324/api/jwt',
        {
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*'
            },
                username: this.state.username,
                password: this.state.password
        })
        .then(result => {
            localStorage.setItem('my-super-cool-jwt', result.data);
            this.props.history.push('/Loged');
        });
    }

    render() {
        return (
            <div>
                <h2>Please login to use the site :)</h2>
                <form onSubmit={event => this.submit(event)}>
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