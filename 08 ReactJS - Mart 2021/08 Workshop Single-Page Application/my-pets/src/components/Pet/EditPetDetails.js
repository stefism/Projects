import { useEffect, useState } from 'react';
import InputError from '../Shared/InputError';
import firebase from 'firebase';

const EditPetDetails = ({match, history}) => {
    const [pet, setPet] = useState({});
    const [errorMessage, setErrorMessage] = useState('');
    const [buttonDisabled, setButtonDisabled] = useState(true);

    useEffect(() => {
        var db = firebase.firestore();
        var currentPet = db.collection('pets').doc(match.params.petId);

        currentPet.get().then((doc) => {
            var pet = {
                id: doc.id,
                category: doc.get('category'),
                description: doc.get('description'),
                imageURL: doc.get('imageURL'),
                likes: doc.get('likes'),
                name: doc.get('name'),
                user: doc.get('user')
            }

            setPet(pet);
        });
    }, [match]);

    const onDescriptionSaveSubmit = (e) => {
        e.preventDefault();

        console.log(e.target.petName.value);

        let updatedPet = {...pet,
            name: e.target.petName.value,
            description: e.target.description.value,
            imageURL: e.target.imageURL.value
        };

        console.log(updatedPet);

        // petService.update(petId, updatedPet)
        // .then(() => {
        //     history.push(`/pets/details/${petId}`);
        //     return;
        // });
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

                    <button  className="button">Edit</button>
                    <button className="button">Delete Pet</button>
                </form>
        </section>
    );
};

export default EditPetDetails;