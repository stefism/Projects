import React, { useState } from "react";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";

import ChangePricesForm from '../components/changePricesForm'
import GetUsername from './GetUsername'

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());

  const username = GetUsername();

  return (
    <>
  {username === 'admin@proba.net' && <ChangePricesForm />}
  <Calendar value={selectedDate} 
    onChange={setSelectedDate} />
    </>)
}

export default LogedApp