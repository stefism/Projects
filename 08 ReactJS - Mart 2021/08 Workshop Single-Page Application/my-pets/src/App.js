import './App.css';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Categories from './components/Categories/Categories';
import PetDetails from './components/Pet/PetDetails';
import CreatePet from './components/Pet/CreatePet';

import { Route, Switch } from 'react-router-dom';

function App() {
  return (
    <div className="container">
      <Header />

      <Switch>
        <Route path="/" exact component={Categories} />
        <Route path="/categories/:category" component={Categories} />
        <Route path="/pets/details/:petId" component={PetDetails} />
        <Route path="/pets/create/" component={CreatePet} />
      </Switch>
      
      <Footer />
    </div>
  );
}

export default App;
