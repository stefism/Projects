import React from 'react'

function AllReservations(props){
    return (
        <div>
            <table>
                <tr>{props.username}</tr>
                <tr>{props.reservedDate}</tr>
                <tr>{props.price}</tr>
            </table>
        </div>
    )
}

export default AllReservations;