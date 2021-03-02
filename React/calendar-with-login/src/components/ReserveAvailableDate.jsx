import React from "react";
import { Button, Modal } from 'react-bootstrap'

import 'bootstrap/dist/css/bootstrap.min.css';

async function ReserveAvailableDate(date, userId) {

        const endpoint = `https://localhost:44324/Data/AddAvailableDate?dateToString=${date}&userId=${userId}`;
    
        var success = false;
        await fetch(endpoint, {
            mode: 'cors',
            method: 'POST',
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Headers': '*',
            },
            body: JSON.stringify(
                { 
                    "dateToString": date
                })
        })
        .then(() => {
            success = true;
        }, (e) => {
            window.alert(e);
        })
    
        return { success: success }
    }

    // if(visible == true){
    //     return (
    //         <>
    //           <Modal show={true} onHide={visible = false}>
    //             <Modal.Header closeButton>
    //               <Modal.Title>Confirm reserve date</Modal.Title>
    //             </Modal.Header>
    //             <Modal.Body>The date {date} will be reserve. Do you confirm reservation?</Modal.Body>
    //             <Modal.Footer>
    //               <Button variant="secondary" onClick={visible = false}>
    //                 Cancel
    //               </Button>
    //               <Button variant="primary" onClick={ReserveDate}>
    //                 Confirm
    //               </Button>
    //             </Modal.Footer>
    //           </Modal>
    //         </>
    //       );
    // }
//   }

  export default ReserveAvailableDate;