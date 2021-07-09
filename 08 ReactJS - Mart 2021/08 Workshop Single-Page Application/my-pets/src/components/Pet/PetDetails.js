import { useEffect, useState } from 'react';
import * as petService from '../../Services/PetsService';

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

    return (
      <section class="detailsOtherPet">
      <h3>{pet.name}</h3>
      <p>Pet counter: {pet.likes} <a href="#"><button class="button"><i class="fas fa-heart"></i>Pet</button></a></p>
      <p class="img"><img src={pet.imageURL} /></p>
      <p class="description">{pet.description}</p>
      </section>
    );
};

export default PetDetails;