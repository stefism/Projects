import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";

import ChangePricesForm from '../components/changePricesForm';
import GetUserInfo from './GetUserInfo';
import GetAllReservations from '../components/GetAllReservations';
import AllReservations from '../components/AllReservationsComponent';

import { Button } from 'react-bootstrap';

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());
  const [allReservations, setAllReservations] = useState();
  const [reservedDates, setReservedDates] = useState([]);

  const [showModal, setShowModal] = useState(false);
  const [isModalConfirm, setIsModalConfirm] = useState(false);
  
  const history = useHistory();

  const userInfo = GetUserInfo();

  const routeChange = () =>{ 
    let path = `/AllReservations`; 
    history.push(path);
  }
  
  useEffect(() => {
    GetAllReservations(setAllReservations);
  }, []);

  return (
    <>
       {userInfo.username === 'admin@proba.net' && <ChangePricesForm />}
       <Calendar value={selectedDate} 
                 setAllReservations={setAllReservations} 
                 onChange={setSelectedDate}
                 reservedDates={reservedDates}
                 setReservedDates={setReservedDates} />
        <br/>
        {userInfo.username === 'admin@proba.net' && <Button variant='primary' onClick={routeChange}>Show all reservations</Button>}
       {/* <AllReservations 
       reservations={ allReservations }
       setAllReservations={setAllReservations}
       setReservedDates={setReservedDates}
       setShowModal={setShowModal}
       setIsModalConfirm={setIsModalConfirm}
       showModal={showModal}
       isModalConfirm={isModalConfirm} /> */}
       <br/>
    </>)
}

export default LogedApp