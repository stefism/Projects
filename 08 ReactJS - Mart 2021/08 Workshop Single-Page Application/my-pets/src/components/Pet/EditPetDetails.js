import { useEffect, useState } from 'react';
import InputError from '../Shared/InputError';
import firebase from 'firebase';
import { Modal, Button } from 'react-bootstrap';

const EditPetDetails = ({match, history}) => {
    const [pet, setPet] = useState({});
    const [errorMessage, setErrorMessage] = useState('');
    const [buttonDisabled, setButtonDisabled] = useState(true);

    const [showModal, setShowModal] = useState(false);

    var db = firebase.firestore();

    useEffect(() => {
        
        var currentPet = db.collection('pets').doc(match.params.petId);

        currentPet.get().then((doc) => {
            var pet = {
                category: doc.get('category'),
                description: doc.get('description'),
                imageURL: doc.get('imageURL'),
                likes: doc.get('likes'),
                name: doc.get('name'),
                user: doc.get('user')
            }

            setPet(pet);
        });
    }, [db, match.params.petId]);

    const handleCloseModal = () => setShowModal(false);
    
    const handleShowModal = () => setShowModal(true);

    const handleDeletePet = () => {
        var currentPet = db.collection('pets').doc(match.params.petId);

        currentPet.delete().then(() => {
            history.push(`/categories/myPets`);
            return;
        });
    };

    const onDescriptionSaveSubmit = (e) => {
        e.preventDefault();

        console.log(e.target.petName.value);

        let updatedPet = {...pet,
            name: e.target.petName.value,
            description: e.target.description.value,
            imageURL: e.target.imageURL.value
        };

        var currentPet = db.collection('pets').doc(match.params.petId);

        currentPet.set(updatedPet).then(() => {
                history.push(`/categories/myPets`);
                return;
            });
    };

    const onDescriptionChangeHandler = (e) => {
        console.log(e.target.value);

        if (e.target.value.length < 10) {
            setErrorMessage('Description must be at least 10 characters.');
        } else {
            setErrorMessage('');
        }
    };

    const onChangeHandler = (e) => {
        if (e.target.value.length < 10) {
            setButtonDisabled(true);
        } else {
            setButtonDisabled(false);
        }
    }

    return (
        <>
        <Modal show={showModal} onHide={handleCloseModal}>
            <Modal.Header closeButton>
            <Modal.Title>Warning!</Modal.Title>
            </Modal.Header>

            <Modal.Body>This pet is permanently deleted! Realy want to do this?</Modal.Body>
            
            <Modal.Footer>
            <Button variant="secondary" onClick={handleCloseModal}>
                Cancel
            </Button>
            <Button variant="danger" onClick={handleDeletePet}>
                Delete Pet
            </Button>
            </Modal.Footer>
        </Modal>

        <section className="detailsMyPet">
                <p>Pet counter: <i className="fas fa-heart"></i> {pet.likes}</p>
                <p className="img"><img src={pet.imageURL} alt="" /></p>
                <form onSubmit={onDescriptionSaveSubmit}>
                    <p style={{marginBottom: 1}}><b>Name:</b></p>
                    <h3 style={{marginTop: 10}}>
                    <textarea
                    name="petName"
                    type="text"
                    style={{textAlign: "center", width: 400, marginTop: 1}}
                    defaultValue={pet.name}>
                    </textarea>
                    </h3>
                    
                    <p><b>Description:</b></p>
                    <textarea style={{width: 400}} type="text" 
                    name="description"
                    onBlur={onDescriptionChangeHandler}
                    onChange={onChangeHandler}
                    defaultValue={pet.description}>
                    </textarea>

                    <p><b>Image URL:</b></p>
                    <textarea type="text" 
                    name="imageURL"
                    onChange={onChangeHandler}
                    defaultValue={pet.imageURL}>
                    </textarea>

                    <InputError>{errorMessage}</InputError>

                    <button className="button">Edit</button>
                </form>

                <button onClick={handleShowModal} className="button">Delete Pet</button>
        </section>
        </>
    );
};

export default EditPetDetails;