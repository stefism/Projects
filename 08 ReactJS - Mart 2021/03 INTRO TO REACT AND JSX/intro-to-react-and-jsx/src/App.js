import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';
import Body from './components/Body';
import BookList from './components/BookList';

import './App.css';
import Counter from './components/Counter';

function App() {
  return (
    <>
    <Header>This is props.children</Header>
    <main>
      <Lorem/>
      <Body/>
      <Counter/>
      <BookList/>
    </main>
    <Footer/>
    </>
  );
}

export default App;
