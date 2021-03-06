import React, { useState } from "react";
import { getJwt } from "../login-component/jwt";
import { withRouter } from "react-router-dom";
import axios from "axios";

function GetAllReservations(setAllReservations){
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
                if(result.data){
                    setAllReservations(result.data);
                    return;
                }

                setAllReservations([]); // if result.data is undefine, to not create a empty array.
            });
}

export default GetAllReservations;

// async function GetAllReservations()
// {
//     const jwt = getJwt();
//     const endpoint = "https://localhost:44324/Data/AllReservations";

//     let result = await fetch(endpoint, {
//         mode: "cors",
//         method: "GET",
//         headers: {
//             ContentType: "application/json",
//             Authorization: `Bearer ${jwt}`,
//         },
//     });

//     let resData = await result.json();

//     console.log('Reservations from GetAllReservations.jsx: ' + resData);

//     return resData;
// }

// export default GetAllReservations;
