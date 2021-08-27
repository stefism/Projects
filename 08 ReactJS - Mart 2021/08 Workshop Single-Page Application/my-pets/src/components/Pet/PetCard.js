import { useContext, useState } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../Contexts/AuthContext';
import firebase from 'firebase';

const PetCard = (props) => {
  const [currentLikes, setCurrentLikes] = useState(props.likes);
  const {isAuthenticated, username} = useContext(AuthContext);

  const onPetLikesButtonHandler = () => {
    var db = firebase.firestore();

    db.collection('pets').doc(props.id).set({
      category: props.category,
      description: props.description,
      imageURL: props.imageURL,
      likes: currentLikes + 1,
      name: props.name,
      user: username
    }).then(() => setCurrentLikes(currentLikes + 1));
  }

  return (
    <li className="otherPet">
      <h3>Name: {props.name}</h3>
      <p>Category: {props.category}</p>
      <p className="img">
        <img src={props.imageURL} alt="" />
      </p>
      <p className="description">{props.description}</p>
      <div className="pet-info">
        
      <button disabled={!isAuthenticated} onClick={onPetLikesButtonHandler} className="button"> {currentLikes}  <i style={{color: "blue"}} className="fas fa-thumbs-up"></i></button>

      {props.isMyPets &&
        <Link to={`/pets/details/${props.id}`}><button className="button">Edit Pet</button></Link>
      }  
      </div>
    </li>
  );
}

export default PetCard;