import React, { useState } from "react";
import { getJwt } from "../login-component/jwt";
import { withRouter } from "react-router-dom";
import axios from "axios";
import GetUserInfo from "../login-component/GetUserInfo";

function GetAllReservationsByUser(setAllReservations, userId){
    const jwt = getJwt();

    // const userInfo = GetUserInfo();
    
    const endpoint = `https://localhost:44324/Data/AllReservationsByUser?userId=${userId}`

    axios.get(endpoint, { 
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

export default GetAllReservationsByUser;