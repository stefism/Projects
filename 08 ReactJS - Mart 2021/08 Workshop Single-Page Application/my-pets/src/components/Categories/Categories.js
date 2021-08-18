import { Component } from "react";

import CategoryNavigation from "./CategoryNavigation";
import PetCard from "../Pet/PetCard";
import * as petsService from '../../Services/PetsService';

class Categories extends Component {
  constructor(props) {
    super(props)

    this.state = {
      pets: [],
      currentCategory: 'all'
    }
  }

  componentDidMount() {
    petsService.getAll()
      .then(result => this.setState({ pets: result }));
  }

  componentDidUpdate(prevProps) {
    const category = this.props.match.params.category;
    document.title = `My Pets App - ${category}`;

    // eslint-disable-next-line eqeqeq
    if (prevProps.match.params.category == category) {
      return;
    }

    petsService.getAll(this.props.match.params.category)
      .then(result => this.setState({ pets: result }));
  }

  // onPetLikesButtonHandler(petId, likes) {
  //   petsService.updateLikes(petId, likes + 1)
  //   .then((result) => {
  //     this.setState(state => ({pets: state.pets.map(
  //       pet => pet.id == petId ? {...pet, likes: result.likes} : pet)}
  //       ));
  //   });
  // }

  render() {
    return (
      <section className="dashboard">
        <h1>Dashboard</h1>

        <CategoryNavigation />

        <ul className="other-pets-list">

          {this.state.pets.map(pet =>
            <PetCard
              key={pet.id}
              {...pet} //Когато има много пропертита, с този синтаксис ги дескрукторира и ги подава всичките, за да не се подават по отделно.
            />
          )}

        </ul>
      </section>
    );
  }
}

export default Categories;