import React from "react";

async function ChangePrices(workDaysPrice, weekDaysPrice) {

    const endpoint = 'https://localhost:44324/Home/ChangePrices';

    var success = false;
    await fetch(endpoint, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Headers': '*'
        },
        body: JSON.stringify(
            { 
                Workday: parseFloat(workDaysPrice),
                Weekends: parseFloat(weekDaysPrice)
            })
    })
    .then(() => {
        success = true;
    }, (e) => {
        window.alert(e);
    })

    return { success: success }
}

export default ChangePrices