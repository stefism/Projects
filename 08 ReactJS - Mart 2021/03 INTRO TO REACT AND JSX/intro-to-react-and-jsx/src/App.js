import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';
import Body from './components/Body';
import BookList from './components/BookList';

import './App.css';
import Counter from './components/Counter';

const books = [
  {id: 1, title: 'Harry Potter', description: 'Wizards and stuff'},
  {id: 2, title: 'Programing with JS', description: 'Guide to programming'},
  {id: 3, title: 'The Bible', description: 'Most important book'}
];

function App() {
  return (
    <>
    <Header>This is props.children</Header>
    <main>
      <Lorem/>
      <Body/>
      <Counter/>
      <BookList books={books}/>
    </main>
    <Footer/>
    </>
  );
}

export default App;
