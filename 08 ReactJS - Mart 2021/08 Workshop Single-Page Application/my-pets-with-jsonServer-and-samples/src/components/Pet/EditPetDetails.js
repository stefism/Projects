import { useEffect, useState } from 'react';
import * as petService from '../../Services/PetsService';
import InputError from '../Shared/InputError';

const EditPetDetails = ({match, history}) => {
    const [pet, setPet] = useState({});
    const [errorMessage, setErrorMessage] = useState('');
    const [buttonDisabled, setButtonDisabled] = useState(true);

    useEffect(() => {
        petService.getOne(match.params.petId)
        .then(res => setPet(res));
    }, [match]);

    const onDescriptionSaveSubmit = (e) => {
        e.preventDefault();
        console.log(e.target);

        let petId = match.params.petId;
        let updatedPet = {...pet, description: e.target.description.value};

        petService.update(petId, updatedPet)
        .then(() => {
            history.push(`/pets/details/${petId}`);
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
        <section className="detailsMyPet">
                <h3>{pet.name}</h3>
                <p>Pet counter: <i className="fas fa-heart"></i> {pet.likes}</p>
                <p className="img"><img src={pet.imageURL} alt="" /></p>
                <form onSubmit={onDescriptionSaveSubmit}>
                    <textarea type="text" 
                    name="description"
                    onBlur={onDescriptionChangeHandler}
                    onChange={onChangeHandler}
                    defaultValue={pet.description}>

                    </textarea>
                    <InputError>{errorMessage}</InputError>
                    <button disabled={buttonDisabled} className={buttonDisabled ? "disabled" : "button"}>Save</button>
                </form>
        </section>
    );
};

export default EditPetDetails;