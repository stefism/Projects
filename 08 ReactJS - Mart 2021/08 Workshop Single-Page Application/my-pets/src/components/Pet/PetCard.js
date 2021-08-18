import { useState } from 'react';
import { Link } from 'react-router-dom';
import * as petsService from '../../Services/PetsService';

const PetCard = (props) => {
  const [currentLikes, setCurrentLikes] = useState(props.likes);

  const onPetLikesButtonHandler = () => {
    petsService.updateLikes(props.id, currentLikes + 1)
      .then((result) => {
        setCurrentLikes(result.likes);
      });
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
        <button onClick={onPetLikesButtonHandler} className="button"><i className="fas fa-heart"></i>Pet</button>
        <Link to={`/pets/details/${props.id}`}>
          <button className="button">Details</button>
        </Link>
        <i className="fas fa-heart"></i> <span>{currentLikes}</span>
      </div>
    </li>
  );
}

export default PetCard;