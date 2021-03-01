import React from "react";

async function GetPricesFromApi(year = 2021, month = 3) {
    const endpoint = `https://localhost:44324/Data/GetReservedDates?year=${year}&month=${month}`;

    const result = await fetch(endpoint, {
      mode: 'cors',
      method: 'GET',
      headers: {
        'Accept': '*/*',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': '*'
      },
    })
      .then(response => response.json())
      .then((result) => {
        return result;
      }, (e) => {
        window.alert(e);
      })

    return result;
  }

  export default GetPricesFromApi;