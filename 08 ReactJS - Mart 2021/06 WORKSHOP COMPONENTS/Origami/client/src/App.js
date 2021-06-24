import style from './App.module.css';
import Header from './components/Header/Header';
import Menu from './components/Menu/Menu';
import Main from './components/Main/Main';
import { Component } from 'react';
import * as postServices from './services/postServices';
import About from './components/About/About';
import { Route, Switch } from "react-router-dom";

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      posts: [],
      selectedPost: null
    }
  }
  
  async componentDidMount() {
    await postServices.getAll()
    .then(p => {
      this.setState({posts: p})
    });
  }

  onMenuItemClick(id) {
    this.setState({selectedPost: id});
  }

  getPosts() {
    if(!this.state.selectedPost) {
      return this.state.posts;
    } else {
      return [this.state.posts.find(post => post.id == this.state.selectedPost)];
    }
  }

  render() {
    return (
      <div className={style.app}>      
        <Header/>
        <div className={style.container}>
        
        <Menu 
          onMenuItemClick={this.onMenuItemClick.bind(this)} 
        />
        <Switch>
          <Route path="/" exact>
            <Main 
              posts={this.getPosts()}
            />
          </Route>
          <Route path="/about/:name" component={About}></Route>
          <Route render={() => <h1>Error Page</h1>} />
        </Switch> 
        </div>        
      </div>
    );
  }
}

export default App;