import React, { useState } from 'react';
import { getJwt } from '../login-component/jwt'
import { withRouter } from 'react-router-dom';
import axios from 'axios';

function GetAllReservations(){
    const [reservations, setReservations] = useState({});

    const jwt = getJwt();

    axios.get('https://localhost:44324/Data/AllReservations', { 
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
                Authorization: `Bearer ${jwt}` 
            } })
            .then((result) => {
                setReservations(result.data);
               }
           );
            return {reservations}
}

export default GetAllReservations;