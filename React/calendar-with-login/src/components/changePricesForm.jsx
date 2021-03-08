import React, { useState } from "react";
import ChangePrices from '../components/changePrices'

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
        <div>
            <h3>Change prices</h3>

            <form class='change-prices' onSubmit={handleSubmit}>
            <label for='work-days'>Work days: </label>
            <input value={workDaysPrice} onChange={handleChangeWorkDays}
            name='work-days' type='number' step="any"/>
            
            <br/>
            <label for='week-days'>Week days: </label>
            <input value={weekDaysPrice} onChange={handleChangeWeekDays}
            name='week-days' type='number' step="any"/>
            
            <br/>
            <button>Change</button>
            </form>
        </div>
    )
}

export default ChangePricesForm