import React, { useState } from 'react'
import {Modal, Button} from 'react-bootstrap'

function ReserveDateModal(){
  const [show, setShow] = useState(true);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

    return(
        <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Confirm reservation</Modal.Title>
        </Modal.Header>
        <Modal.Body>Confirm reservation on this date?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Confirm
          </Button>
        </Modal.Footer>
      </Modal>
    )
}

export default ReserveDateModal;