import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import { auth } from './Config/firebase';

import { Route, Switch, Redirect } from 'react-router-dom';
import { useEffect, useState } from 'react';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Categories from './components/Categories/Categories';
import CreatePet from './components/Pet/CreatePet';
import EditPetDetails from './components/Pet/EditPetDetails';
import LoginPage from './components/Authentication/LoginPage';
import RegisterPage from './components/Authentication/RegisterPage';

import ErrorBoundary from './components/ErrorBoundaries/ErrorBoundary';

import AuthContext from './components/Contexts/AuthContext';
import RouteGuard from './HighOrderedComponents/RouteGuard';

function App() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    auth.onAuthStateChanged(setUser);
  }, []);

  const authInfo = {
    isAuthenticated: Boolean(user),
    username: user?.email
  }

  return (
    <div className="container">
      <AuthContext.Provider value={authInfo}>
      
      <Header />

      <ErrorBoundary>
      <Switch>
        <Route path="/" exact component={Categories} />
        <Route path="/categories/:category" component={Categories} />
        <Route path="/pets/details/:petId" exact component={RouteGuard(EditPetDetails)} />
        <Route path="/pets/create/" component={RouteGuard(CreatePet)} />
        <Route path="/login" component={LoginPage} />
        <Route path="/register" component={RegisterPage} />
        
        <Route path="/logout" render={props => {
          auth.signOut();
          return <Redirect to="/" />
        }} />
      </Switch>
      </ErrorBoundary>

      <Footer />

      </AuthContext.Provider>
    </div>
  );
}

export default App;