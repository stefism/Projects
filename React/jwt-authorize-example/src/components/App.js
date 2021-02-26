import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Home from '../components/Home';
import Authenticate from '../components/Authenticate';
import Login from './Login';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
      <Switch>
        <Route path="/Login" component={Login} />
        <Route path="/" exact component={Home} />
      </Switch>
      </BrowserRouter>
    );
  }
}

export default App;
