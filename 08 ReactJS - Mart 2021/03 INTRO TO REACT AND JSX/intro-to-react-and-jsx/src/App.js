import Header from './components/Header';
import Footer from './components/Footer';
import Lorem from './components/Lorem';

import './App.css';

function App() {
  return (
    <>
    <Header>This is props.children</Header>
    <main>
      <Lorem/>
      <Lorem/>
    </main>
    <Footer/>
    </>
  );
}

export default App;
