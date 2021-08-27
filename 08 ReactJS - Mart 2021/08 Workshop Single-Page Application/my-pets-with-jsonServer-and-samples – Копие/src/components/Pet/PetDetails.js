import { useEffect, useState } from 'react';
import * as petService from '../../Services/PetsService';
import { Link } from 'react-router-dom';

const PetDetails = ({match}) => {
    let [pet, setPet] = useState({});

    useEffect(() => {
        petService.getOne(match.params.petId)
        .then(res => setPet(res));
    }, [match]);

    // [match] - [] - Този празен масив означава - Не депендвам на нищо. 
    // Искам веднъж като се зареди страницата, да ми извикаш това нещо и повече
    // никога да не го извикваш. Нещо като componentDidMount() метода.
    // Когато използваме нещо от вънка (в случая 'match'), е хубаво да го поставим
    // вътре в масива. Така, ако 'match' се промени, това дето е в useEffect ще се изпълни на ново.

    const onPetButtonClickHandler = () => {
      let incrementedLikes = pet.likes + 1;

      petService.updateLikes(match.params.petId, incrementedLikes)
      .then((updatedPet) => { //updatedPet - сървъра ни връща актуализирания пет.
        setPet(state => ({...state, likes: updatedPet.likes}))
      });
    };
    
    return (
      <section className="detailsOtherPet">
      <h3>{pet.name}</h3>
      <p>Pet counter: {pet.likes} 
      <button onClick={onPetButtonClickHandler} className="button"><i className="fas fa-heart"></i>Pet</button>
      </p>
      <p className="img"><img src={pet.imageURL} alt=""/></p>
      <p className="description">{pet.description}</p>
      
      <div className="pet-info">
        <Link to={`/pets/details/${pet.id}/edit`}><button className="button">Edit</button></Link>
        <Link to="#"><button className="button">Delete</button></Link>
      </div>
      </section>
    );
};

export default PetDetails;