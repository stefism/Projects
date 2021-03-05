import React from 'react'

import "../app/calendar/styles.css";
import ReleaseReservation from './ReleaseReservation'
import GetAllReservations from '../components/GetAllReservations';
import GetPricesFromApi from '../components/GetPricesFromApi';

function AllReservations(props){
    
    function handle(event){
        const date = new Date(event.target.getAttribute('currDate'))

        const currentYear = date.getFullYear();
        const currMonth = date.getMonth() + 1;

        ReleaseReservation(event.target.value)
        .then((result) => {
            if(result.success){
              GetAllReservations(props.setAllReservations);

              GetPricesFromApi(currentYear, currMonth).then((result) => {
                const resDates = result.reservedDays.map(d => d.reservedDate.split('T')[0]);
                props.setReservedDates(resDates)
              });
            }
        });
    }

    return <div>
        <table id='all-reservations'>
            <th>Username</th>
            <th>Reservation date</th>
            <th>Price</th>
            <th>Delete</th>
            { //Проверявам дали не е undefined и ако не е правя map
            props.reservations && props.reservations.map(item => 
                <tr>
                <td>{item.username}</td>
                <td>{item.reservedDate}</td>
                <td>{item.price}</td>
                <td><button value={item.reservationDateId}
                    currDate = {item.reservedDate}
                    class="del-reservations" 
                    onClick={event => handle(event)}>Delete</button></td>
                </tr>
                )
            }        
        </table>
        </div>
    
}

export default AllReservations;

// function AllReservations(props){
//     return (
//         <div>
//             <table>
//                 <tr>{props.reservationDateId}</tr>
//                 <tr>{props.username}</tr>
//                 <tr>{props.reservedDate}</tr>
//                 <tr>{props.price}</tr>
//             </table>
//         </div>
//     )
// }

// export default AllReservations;