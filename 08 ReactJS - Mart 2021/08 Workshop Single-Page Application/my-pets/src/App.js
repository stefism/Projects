import './App.css';
import { Route, Switch } from 'react-router-dom';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Categories from './components/Categories/Categories';
import PetDetails from './components/Pet/PetDetails';
import CreatePet from './components/Pet/CreatePet';
import EditPetDetails from './components/Pet/EditPetDetails';

import DemoPage from './components/Demo/DemoPage';

function App() {
  return (
    <div className="container">
      <Header />

      <Switch>
        <Route path="/" exact component={Categories} />
        <Route path="/categories/:category" component={Categories} />
        <Route path="/pets/details/:petId" exact component={PetDetails} />
        <Route path="/pets/details/:petId/edit" component={EditPetDetails} />
        <Route path="/pets/create/" component={CreatePet} />

        <Route path="/demo" component={DemoPage} />
      </Switch>
      
      <Footer />
    </div>
  );
}

export default App;
