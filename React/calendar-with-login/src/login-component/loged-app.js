import React, { useState } from "react";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";

import ChangePricesForm from '../components/changePricesForm'

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());
  return (
    <>
  <ChangePricesForm />
  <Calendar value={selectedDate} 
    onChange={setSelectedDate} />
    </>)
}

export default LogedApp