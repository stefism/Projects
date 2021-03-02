import React, { useState } from 'react';
import { getJwt } from './jwt'
import { withRouter } from 'react-router-dom';
import axios from 'axios';

function GetUserInfo() {
    const [username, setUsername] = useState();
    const [userId, setUserId] = useState();

    const jwt = getJwt();

    axios.get('https://localhost:44324/api/jwt', { 
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
                Authorization: `Bearer ${jwt}` 
            } })
            // .then(result => setUsername(result.data.username), 
            // result => setUserId(result.data.userId));
            // ТАКА КАТО ГОРНОТО - НЕ РАБОТИ! КАТО ДОЛНОТО РАБОТИ! Резулта в скоби!
            .then((result) => { //Когато се сетва повече от един аргумент, се пише така!
                setUsername(result.data.username);
                setUserId(result.data.userId)
               }
           );
            return {username: username, userId: userId}

//    return username; 
}

export default GetUserInfo;