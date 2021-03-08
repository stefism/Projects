import React from 'react';
import {Modal, Button} from 'react-bootstrap';
import ReleaseReservation from './ReleaseReservation';
import GetAllReservations from '../components/GetAllReservations';
import GetPricesFromApi from '../components/GetPricesFromApi';

function DeleteReservedDate(props) {
    const handleClose = () => props.setShowModal(false);
    
    const isModalConfirm = () => {
        props.setIsModalConfirm(true);
        props.setShowModal(false);

        let currentYear = props.dateToDelete.getFullYear();
        let currMonth = props.dateToDelete.getMonth() + 1;

        ReleaseReservation(props.dateId)
             .then((result) => {
                 if(result.success){
                   GetAllReservations(props.setAllReservations);

                   GetPricesFromApi(currentYear, currMonth).then((result) => {
                     const resDates = result.reservedDays.map(d => d.reservedDate.split('T')[0]);
                     props.setReservedDates(resDates)});
                }
            });
    }
    
    return(
        <Modal show={props.showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Delete reservation confirm</Modal.Title>
        </Modal.Header>
        <Modal.Body>The reserved date {props.deletedDate} has been deleted. Confirm delete reservation?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={isModalConfirm}>
            Confirm
          </Button>
        </Modal.Footer>
      </Modal>
    )
}

export default DeleteReservedDate;