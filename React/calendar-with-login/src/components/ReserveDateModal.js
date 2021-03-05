import React from 'react'
import {Modal, Button} from 'react-bootstrap'

import GetUserInfo from '../login-component/GetUserInfo';
import GetAllReservations from '../components/GetAllReservations';
import ReserveAvailableDate from '../components/ReserveAvailableDate';

function ReserveDateModal(props){
  const userInfo = GetUserInfo();

  const handleClose = () => props.setShowModal(false);
  
  const isModalConfirm = () => {
    ReserveAvailableDate(props.dateToChange, userInfo.userId)
    .then((result) => {
        if(result.success){
          GetAllReservations(props.setAllReservations);
        }
    });

    props.setShowModal(false);
  }

    return(
        <Modal show={props.showModal} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Confirm reservation</Modal.Title>
        </Modal.Header>
        <Modal.Body>Confirm reservation on {props.selectedDate}?</Modal.Body>
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

export default ReserveDateModal;