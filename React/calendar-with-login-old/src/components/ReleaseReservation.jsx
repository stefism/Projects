import React from "react";

async function ReleaseReservation(reservationId) {

        const endpoint = `https://localhost:44324/Data/ReleaseReservaton?reservationId=${reservationId}`;
    
        var success = false;
        await fetch(endpoint, {
            mode: 'cors',
            method: 'POST',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
            },
            body: JSON.stringify(
                { 
                    "dateToString": reservationId
                })
        })
        .then(() => {
            success = true;
        }, (e) => {
            window.alert(e);
        })
    
        return { success: success }
    }

  export default ReleaseReservation;