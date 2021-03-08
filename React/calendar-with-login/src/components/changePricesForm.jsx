import React, { useState } from "react";
import ChangePrices from '../components/changePrices'
import { Button } from 'react-bootstrap';
import '../app/calendar/styles.css'

function ChangePricesForm() {
    const [workDaysPrice, setWorkDaysPrice] = useState(0);
    const [weekDaysPrice, setWeekDaysPrice] = useState(0);

    function handleChangeWeekDays(e){
        setWeekDaysPrice(e.target.value)
    }

    function handleChangeWorkDays(e){
        setWorkDaysPrice(e.target.value)
    }

    function handleSubmit(e){
        ChangePrices(workDaysPrice, weekDaysPrice);
    }

    return (
        <div class='change-prices'>
            
            <h3>Change prices</h3>

            <form onSubmit={handleSubmit}>
            <label class='input-field' for='work-days'>Work days: </label>
            <input class='input-field' value={workDaysPrice} onChange={handleChangeWorkDays}
            name='work-days' type='number' step="any"/>
            
            <label class='input-field' for='week-days'>Week days: </label>
            <input class='input-field' value={weekDaysPrice} onChange={handleChangeWeekDays}
            name='week-days' type='number' step="any"/>
            
            <button class='btn-submit'>Change</button>
            </form>
            
        </div>
    )
}

export default ChangePricesForm