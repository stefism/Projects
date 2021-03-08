import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';
import Body from './components/Body';
import BookList from './components/BookList';

import './App.css';

const books = [
  {title: 'Harry Potter', description: 'Wizards and stuff'},
  {title: 'Programing with JS', description: 'Guide to programming'},
  {title: 'The Bible', description: 'Most important book'}
];

function App() {
  return (
    <>
    <Header>This is props.children</Header>
    <main>
      <Lorem/>
      <Body/>
      <BookList books={books}/>
    </main>
    <Footer/>
    </>
  );
}

export default App;
