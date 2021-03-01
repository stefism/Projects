import React, { useState } from 'react';
import { getJwt } from './jwt'
import { withRouter } from 'react-router-dom';
import axios from 'axios';

function GetUsername() {
    const [username, setUsername] = useState();

    const jwt = getJwt();

    axios.get('https://localhost:44324/api/jwt', { 
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
                Authorization: `Bearer ${jwt}` 
            } })
            .then(result => setUsername(result.data));

   return username; 
}

export default GetUsername;