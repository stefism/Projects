import React, { useState } from "react";
import moment from "moment";
import Calendar from "./calendar/Calendar";
import "./styles.css";

import ChangePricesForm from '../components/changePricesForm'

export default function () {
  const [selectedDate, setSelectedDate] = useState(moment());
  return (
    <>
  <ChangePricesForm />
  <Calendar value={selectedDate} 
    onChange={
      setSelectedDate
    } 
    />

    </>)
}
