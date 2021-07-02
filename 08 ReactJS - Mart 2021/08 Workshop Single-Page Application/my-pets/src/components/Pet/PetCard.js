import { Link } from 'react-router-dom';

const PetCard = (props) => {
    return (
        <li className="otherPet">
            <h3>Name: {props.name}</h3>
            <p>Category: {props.category}</p>
            <p className="img">
              <img src={props.imageURL} />
            </p>
            <p className="description">{props.description}</p>
            <div className="pet-info">
              <Link to="#">
                <button className="button">
                  <i className="fas fa-heart"></i> Pet
                </button>
              </Link>
              <Link to={`/pets/details/${props.id}`}>
                <button className="button">Details</button>
              </Link>
              <i className="fas fa-heart"></i> <span> {props.likes}</span>
            </div>
          </li>
    );
}

export default PetCard;