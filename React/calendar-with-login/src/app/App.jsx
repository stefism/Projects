import React from "react";
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import "./styles.css";

import LogedApp from '../login-component/loged-app';
import Login from '../login-component/Login';
import Authenticate from '../login-component/Authenticate';

import 'bootstrap/dist/css/bootstrap.min.css';


export default function () {
  return (
    <BrowserRouter>
    <Switch>
    
    <Route path='/' exact component={Login} />
    
    <Authenticate>
    <Route path='/Loged'component={LogedApp}/>
    </Authenticate>
    
    </Switch>
    </BrowserRouter>
  );
}
