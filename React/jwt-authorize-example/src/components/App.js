import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Home from '../components/Home';
import Authenticate from './Authenticate';
import Loged from './Loged';

import Login from './Login';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
      <Switch>
        <Route path='/Login' component={Login} />
        <Route path='/' exact component={Home} />
        <Authenticate>
        <Route path='/Loged'component={Loged}/>
        </Authenticate>
        
      </Switch>
      </BrowserRouter>
    );
  }
}

export default App;
