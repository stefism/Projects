import React, { useState } from "react";
import moment from "moment";
import Calendar from "./calendar/Calendar";
import "./styles.css";

export default function () {
  const [selectedDate, setSelectedDate] = useState(moment());
  return <Calendar value={selectedDate} 
  onChange={
    setSelectedDate
    
  } 
  />;
}
