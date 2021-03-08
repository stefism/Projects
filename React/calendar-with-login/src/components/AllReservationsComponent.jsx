import React, { useState } from 'react'
import DeleteReservedDate from './DeleteReservedDateModal';
import "../app/calendar/styles.css";

function AllReservations(props){
    const [dateProp, setDateProp] = useState();
    const [dateId, setDateId] = useState();
    
    function handle(event){
        const date = new Date(event.target.getAttribute('currDate'))
        // dateToDelete = date; 
        setDateProp(date);
        setDateId(event.target.value)
        props.setShowModal(true);
    }

    return <div>
        <DeleteReservedDate
        showModal={props.showModal}
        setShowModal={props.setShowModal}
        dateToDelete={dateProp}
        setIsModalConfirm={props.setIsModalConfirm}
        setAllReservations={props.setAllReservations}
        setReservedDates={props.setReservedDates}
        dateId={dateId}/>

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