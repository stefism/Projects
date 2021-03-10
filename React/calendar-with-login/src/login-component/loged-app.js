import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import moment from "moment";
import Calendar from "../app/calendar/Calendar";
import "../app/calendar/styles.css";
import { getJwt } from './jwt';
import axios from 'axios';

import ChangePricesForm from '../components/changePricesForm';
import AllReservations from '../components/AllReservationsComponent';
import { Button } from 'react-bootstrap';
import GetAllReservationsByUser from "../components/GetAllReservationsByUser";

function LogedApp () {
  const [selectedDate, setSelectedDate] = useState(moment());
  const [allReservations, setAllReservations] = useState();
  const [reservedDates, setReservedDates] = useState([]);

  const [showModal, setShowModal] = useState(false);
  const [isModalConfirm, setIsModalConfirm] = useState(false);

  const [username, setUsername] = useState();
  const [userId, setUserId] = useState();
  
  const history = useHistory();
  
  // const userInfo = GetUserInfo(); //Това вече не работи тука, защото дава грешка, че стейта се сетва в GetUserInfo().
  // За да работи, трябва тука в този файл да сетнем стейта на username и userId, което правим тук с
  // const getUserInfo ... (на 36ти ред) а не във функцията GetUserInfo.js, която ползвахме до сега.

  const routeChange = () =>{ 
    let path = `/AllReservations`; 
    history.push(path);
  }
  
  const getUserInfo = () => { // Взимаме юзър инфото тук, за да може тук да го сетнем в стейта.
    const jwt = getJwt();

    const result = axios.get('https://localhost:44324/api/jwt', { 
            mode: 'cors',
            headers: {
                'Accept': '*/*',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
                Authorization: `Bearer ${jwt}` 
            } });
            
            return result // This is a Promise. (Task that is not complete.)
  }

  useEffect(() => {
    
    (async () => {
      const completedResult = await getUserInfo(); 
        // За да изчакаме result да се изпълни, трябва да му сложим отпред await.
        // След това completedResult вече няма да е promise. Вече ще е изпълнен.

    setUsername(completedResult.data.username); //Когато ползвам axios, трябва да се пише .data.нещо-си.
    setUserId(completedResult.data.userId);
    
    GetAllReservationsByUser(setAllReservations, completedResult.data.userId);
    // Понеже "хука" (hook) на setUserId е асинхронен и все още няма да се е ъпдейтнал, неможем да го
    // ползваме долу във функцията GetAllReservationsByUser. Затова слагаме като втори параметър
    // completedResult.data.userId. Него го имаме вече налично.
    })() //() последните две скоби карат функцията да се изпълни веднага след като се дефинира.

  }, []);


  return (
    <>
       {username === 'admin@proba.net' && <ChangePricesForm />}
       <Calendar value={selectedDate} 
                 setAllReservations={setAllReservations} 
                 onChange={setSelectedDate}
                 reservedDates={reservedDates}
                 setReservedDates={setReservedDates} />
        <br/>
        {username === 'admin@proba.net' && <Button variant='primary' onClick={routeChange}>Show all reservations</Button>}
       <AllReservations
       isFromAllReservations={false}
       userId={userId}
       reservations={ allReservations }
       setAllReservations={setAllReservations}
       setReservedDates={setReservedDates}
       setShowModal={setShowModal}
       setIsModalConfirm={setIsModalConfirm}
       showModal={showModal}
       isModalConfirm={isModalConfirm} />
       <br/>
    </>)
}

export default LogedApp