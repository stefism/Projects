import { Component } from "react";

import CategoryNavigation from "./CategoryNavigation";
import PetCard from "../Pet/PetCard";
import AuthContext from "../Contexts/AuthContext";

import firebase from "firebase";

class Categories extends Component {
  static contextType = AuthContext;

  constructor(props) {
    super(props)

    this.state = {
      pets: [],
      currentCategory: 'all',
      userName: ''
    }
  }

  componentDidMount() {
    const user = this.context;
    this.setState({userName: user.username})
    
    this.getDataFromDb();
  }

  componentDidUpdate(prevProps) {
    const category = this.props.match.params.category;
    const urlPath = this.props.match.path;

    category != undefined ? document.title = `My Pets App - ${category}` : document.title = `My Pets App - ${urlPath}`;

    if (prevProps.match.params.category == category) {
      return;
    }

    const user = this.context;
    this.setState({userName: user.username})
    
    this.getDataFromDb("category", category);
  }

  getDataFromDb(property, value) {
    var db = firebase.firestore();

    var currPets = [];

    if(value == 'all') {
      value = undefined;
      property = undefined;
    }
    
    if(value == 'myPets') {
      value = this.state.userName;
      property = 'user';
    }

    if(property != undefined && value != undefined) {
      db.collection('pets')
      .where(`${property}`, "==", `${value}`)
      .get()
      .then((querySnapshot) => {
        
        querySnapshot.forEach((doc) => {
          var pet = {
            id: doc.id,
            name: doc.get('name'),
            description: doc.get('description'),
            imageURL: doc.get('imageURL'),
            category: doc.get('category'),
            likes: doc.get('likes')
          };

          currPets.push(pet);
        })
      })
      .then(() => this.setState({pets: currPets}))
      .catch(err => console.log(err));
    } else {
      db.collection('pets')
      .get()
      .then((querySnapshot) => {
        
        querySnapshot.forEach((doc) => {
          var pet = {
            id: doc.id,
            name: doc.get('name'),
            description: doc.get('description'),
            imageURL: doc.get('imageURL'),
            category: doc.get('category'),
            likes: doc.get('likes')
          };

          currPets.push(pet);
        })
    })
    .then(() => this.setState({pets: currPets}))
    .catch(err => console.log(err));
    }
  }

  render() {
    return (
      <section className="dashboard">
        <h1>Dashboard - {this.props.match.params.category}</h1>

        <CategoryNavigation />

        <ul className="other-pets-list">

          {this.state.pets.map(pet =>
            <PetCard
              key={pet.id}
              {...pet}
            />
          )}

        </ul>
      </section>
    );
  }
}

export default Categories;