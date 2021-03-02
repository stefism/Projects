import React, { useState, useEffect } from "react";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";

import ChangePricesForm from '../components/changePricesForm';
import GetUserInfo from './GetUserInfo';
import GetAllReservations from '../components/GetAllReservations';
import AllReservations from '../components/AllReservationsComponent'

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());
  // const [allReservations, setAllReservations] = useState();

  const userInfo = GetUserInfo();

  const reservations = GetAllReservations();
  console.log(reservations);
  
  
  // useEffect(() => {
  //   const reservations = GetAllReservations();
  //   console.log(reservations);

  // }, []);
  
  // setAllReservations = GetAllReservations();
  // console.log(allReservations);
  
  // let allReservationsComponents = allReservations.map(item =>
  //   <AllReservations key={item.reservationDateId} 
  //   username={item.username}
  //   reservedDate={item.reservedDate}
  //   price={item.price} />)

  // let allReservationsComponents;

  // for (let i = 0; i < allReservations.length; i++) {
  //   let item = <AllReservations 
  //   key={allReservations[i].reservationDateId}
  //   username={allReservations[i].username}
  //   reservedDate={allReservations[i].reservedDate}
  //   price={allReservations[i].price}
  //   />
    
  //   allReservationsComponents.push(item);
  // }

  return (
    <>
  {userInfo.username === 'admin@proba.net' && <ChangePricesForm />}
  <Calendar value={selectedDate} onChange={setSelectedDate} />
  {/* {allReservationsComponents} */}
    </>)
}

export default LogedApp