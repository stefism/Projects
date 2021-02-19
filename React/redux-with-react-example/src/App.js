// install Redux;
// from terminal -> npm i redux react-redux redux-thunk

import './App.css';
import { Provider } from "react-redux";

import Posts from "./components/Posts";
import Postform from './components/Postform';

import store from './store'



function App() {
  return (
    <Provider store={store}>
      <div className="App">
        <Postform/>
        <hr/>
        <Posts/>
      </div>
    </Provider>
    // Provider tag is need to use Redux
  );
}

export default App;
