import React, { useState } from "react";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";

import ChangePricesForm from '../components/changePricesForm'
import GetUserInfo from './GetUserInfo'

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());

  const userInfo = GetUserInfo();

  return (
    <>
  {userInfo.username === 'admin@proba.net' && <ChangePricesForm />}
  <h3>Username: {userInfo.username}</h3>
  <h3>UserId: {userInfo.userId}</h3>
  <Calendar value={selectedDate} 
    onChange={setSelectedDate} />
    </>)
}

export default LogedApp