import React from "react";
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import LogedApp from '../login-component/loged-app';
import Login from '../login-component/Login';
import Authenticate from '../login-component/Authenticate';

import 'bootstrap/dist/css/bootstrap.min.css';
import "./styles.css";
import LogedAllReservations from "../login-component/loged-allReservations";


export default function () {
  return (
    <BrowserRouter>
    <Switch>
    
    <Route path='/' exact component={Login} />
    
    <Authenticate>
    <Route path='/Loged'component={LogedApp}/>
    <Route path='/AllReservations' component={LogedAllReservations}/>
    </Authenticate>
    
    </Switch>
    </BrowserRouter>
  );
}
