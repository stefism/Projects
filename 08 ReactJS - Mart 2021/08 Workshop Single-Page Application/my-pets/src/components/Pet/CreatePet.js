import * as petsService from "../../Services/PetsService";
import firebase from "firebase";
import AuthContext from "../Contexts/AuthContext";
import { useContext, useState } from "react";

const CreatePet = ({history}) => {
    const { username } = useContext(AuthContext);
    
    const [errMsg, setErrMsg] = useState('');
    const [isError, setIsError] = useState(false);

    const onCreatePetSubmitHandler = (e) => {
        e.preventDefault();

        var db = firebase.firestore();
        const {name, description, imageURL, category} = e.target;

        if(name.value === undefined || name.value.length < 5) {
            setIsError(true);
            setErrMsg('Please enter a Pet name with minimum 5 characters.');
        } else if(description.value.length < 10 || description.value == undefined) {
            setIsError(true);
            setErrMsg('Please enter a Description with minimum 10 characters.');
        } else if(!imageURL.value.includes('http') || imageURL.value.length < 15 || imageURL.value == undefined) {
            setIsError(true);
            setErrMsg('Please enter a valid imageURL.');
        } else {
            db.collection('pets').add({
                category: category.value,
                description: description.value,
                imageURL: imageURL.value,
                likes: 0,
                name: name.value,
                user: username
            })
            .then(() => {history.push('/')});
        }
    };

    return (
        <section className="create">
           <form onSubmit={onCreatePetSubmitHandler}>
               <fieldset>
                   <legend>Add new Pet</legend>
                   <p className="field">
                       <label htmlFor="name">Name</label>
                       <span className="input">
                           <input onFocus={() => setIsError(false)} type="text" name="name" id="name" placeholder="Name" />
                           <span className="actions"></span>
                       </span>
                   </p>
                   <p className="field">
                       <label htmlFor="description">Description</label>
                       <span className="input">
                           <textarea onFocus={() => setIsError(false)} rows="4" cols="45" type="text" name="description" id="description"
                               placeholder="Description"></textarea>
                           <span className="actions"></span>
                       </span>
                   </p>
                   <p className="field">
                       <label htmlFor="image">Image URL</label>
                       <span className="input">
                           <input onFocus={() => setIsError(false)} type="text" name="imageURL" id="image" placeholder="Image URL (must start with http:// or https://)" />
                           <span className="actions"></span>
                       </span>
                   </p>
                   <p className="field">
                       <label htmlFor="category">Category</label>
                       <span className="input">
                           <select type="text" name="category">
                               <option value="Cat">Cat</option>
                               <option value="Dog">Dog</option>
                               <option value="Parrot">Parrot</option>
                               <option value="Reptile">Reptile</option>
                               <option value="Other">Other</option>
                           </select>
                           <span className="actions"></span>
                       </span>
                   </p>
                   <input className="button submit" type="submit" value="Add Pet" />
                    {isError &&
                        <label style={{color: "red"}} htmlFor="">{errMsg}</label>
                    }
               </fieldset>
           </form>
        </section>
    );
};

export default CreatePet;