import React, { useState, useEffect } from "react";
import "../app/calendar/styles.css";

import GetAllReservations from '../components/GetAllReservations';
import AllReservations from '../components/AllReservationsComponent';
import { Button } from 'react-bootstrap';
import { useHistory } from "react-router-dom";

function LogedAllReservations () {
  const [allReservations, setAllReservations] = useState();
  const [reservedDates, setReservedDates] = useState([]);

  const [showModal, setShowModal] = useState(false);
  const [isModalConfirm, setIsModalConfirm] = useState(false);

  const history = useHistory();

  const routeChange = () =>{ 
      history.goBack();
  }
  
  useEffect(() => {
    GetAllReservations(setAllReservations);
  }, []);

  return (
    <>   
       <AllReservations 
       reservations={ allReservations }
       setAllReservations={setAllReservations}
       setReservedDates={setReservedDates}
       setShowModal={setShowModal}
       setIsModalConfirm={setIsModalConfirm}
       showModal={showModal}
       isModalConfirm={isModalConfirm} />
       <br/>
       <Button variant='primary' onClick={routeChange}>Back to Calendar</Button>
    </>)
}

export default LogedAllReservations;