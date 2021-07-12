import * as petsService from "../../Services/PetsService"

//History е едно от пропертитата,което се подава на елемента от Route. 
//Ако нямаме Route, който да инжектне History, може да напишем горе: 
//import {WithRouter} from 'react-router-dom'; и най долу да е: export default WithRouter(CreatePet);

const CreatePet = ({history}) => {
    const onCreatePetSubmitHandler = (e) => {
        e.preventDefault(); // Пречи на страницата да се презареди при изпращане на формата. Желано поведение.
        console.log(e.target); // Таргет е самата форма по-долу. Това е форма с неконтролирани елементи.
        console.log(e.target.name.value);
        console.log(e.target.description.value);
        console.log(e.target.category.value);
        //----

        const {name, description, imageURL, category} = e.target;
        
        petsService.create(name.value, description.value, imageURL.value, category.value)
        .then(() => {history.push('/')});
    };

    //Ако нямаме нужда от контролирани елементи, не ги правим.
    //Контролираните елементи минават през стейта на Реакт.
    return (
        <section className="create">
           <form onSubmit={onCreatePetSubmitHandler}>
               <fieldset>
                   <legend>Add new Pet</legend>
                   <p className="field">
                       <label htmlFor="name">Name</label>
                       <span className="input">
                           <input type="text" name="name" id="name" placeholder="Name" />
                           <span className="actions"></span>
                       </span>
                   </p>
                   <p className="field">
                       <label htmlFor="description">Description</label>
                       <span className="input">
                           <textarea rows="4" cols="45" type="text" name="description" id="description"
                               placeholder="Description"></textarea>
                           <span className="actions"></span>
                       </span>
                   </p>
                   <p className="field">
                       <label htmlFor="image">Image</label>
                       <span className="input">
                           <input type="text" name="imageURL" id="image" placeholder="Image" />
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
               </fieldset>
           </form>
        </section>
    );
};

export default CreatePet;