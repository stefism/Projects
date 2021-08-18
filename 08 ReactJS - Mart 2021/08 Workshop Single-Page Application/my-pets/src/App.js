import './App.css';
import { auth } from './Config/firebase';

import { Route, Switch, Redirect } from 'react-router-dom';
import { useEffect, useState } from 'react';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Categories from './components/Categories/Categories';
import PetDetails from './components/Pet/PetDetails';
import CreatePet from './components/Pet/CreatePet';
import EditPetDetails from './components/Pet/EditPetDetails';
import LoginPage from './components/Authentication/LoginPage';
import RegisterPage from './components/Authentication/RegisterPage';

import DemoPage from './components/Demo/DemoPage';
import AdvancedApp from './components/Demo/DemoContext';
import StartContextApp from './components/WithContext/StartContextApp';
import StartReducerApp from './components/WithReducer/StartReducerApp';
import ErrorBoundary from './components/ErrorBoundaries/ErrorBoundary';

function App() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    auth.onAuthStateChanged(setUser);
  }, []);

  return (
    <div className="container">
      <Header username={user?.email} isAuthenticated={Boolean(user)} />

      <ErrorBoundary>
      <Switch>
        <Route path="/" exact component={Categories} />
        <Route path="/categories/:category" component={Categories} />
        <Route path="/pets/details/:petId" exact component={PetDetails} />
        <Route path="/pets/details/:petId/edit" component={EditPetDetails} />
        <Route path="/pets/create/" component={CreatePet} />
        <Route path="/login" component={LoginPage} />
        <Route path="/register" component={RegisterPage} />
        
        <Route path="/logout" render={props => {
          auth.signOut();
          return <Redirect to="/" />
        }} />

        <Route path="/demo" component={DemoPage} />
        <Route path="/demo2" component={AdvancedApp} />
        <Route path="/demo3" component={StartContextApp} />
        <Route path="/demo4" component={StartReducerApp} />
      </Switch>
      </ErrorBoundary>

      <Footer />
    </div>
  );
}

export default App;
