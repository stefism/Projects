import React from 'react'

import "../app/calendar/styles.css";
import ReleaseReservation from './ReleaseReservation'
import GetAllReservations from '../components/GetAllReservations';

function AllReservations(props){
    
    function handle(event){
        ReleaseReservation(event.target.value)
        .then((result) => {
            if(result.success){
              GetAllReservations(props.setAllReservations);
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