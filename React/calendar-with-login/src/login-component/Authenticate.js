import React, { Component } from 'react';
import { getJwt } from './jwt'
import { withRouter } from 'react-router-dom';
import axios from 'axios';

class Authenticate extends Component {
    constructor(props){
        super(props);

       this.state = {
        user: undefined
       } 
    }

    componentDidMount() {
        const jwt = getJwt();

        if(!jwt) {
            this.props.history.push('/');
        }

        axios.get('https://localhost:44324/api/jwt', { 
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
                Authorization: `Bearer ${jwt}` 
            } })
            .then(result => this.setState({user: result.data}))
            .catch(error => {
                localStorage.removeItem('my-super-cool-jwt');
                this.props.history.push('/');
            });
    }

    render() {
        if(this.state.user === undefined) {
            return (
                <div>
                    <h1>Loading ...</h1>
                </div>
            )
        }
        return (
            <div>
                <h3>Welcome {this.state.user}</h3>
                {this.props.children}
            </div>
        )
    }
}

export default withRouter(Authenticate);