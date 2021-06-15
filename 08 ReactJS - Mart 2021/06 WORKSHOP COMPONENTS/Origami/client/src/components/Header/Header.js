import style from './Header.module.css';
import NavigationItem from './NavigationItem/NavigationItem';
import style2 from './NavigationItem/NavigationItem.module.css';

let linkNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]

const Header = () => {
    return (
        <nav className={style.navigation}>
        <ul>
          <li className={style2.listItem}><img width="80px" src="/white-origami-bird.png" alt="white origami"/></li>
          
          {linkNumbers.map(n => <NavigationItem key={n}>Going to {n}</NavigationItem>)}
        </ul>   
      </nav>
    );
};

export default Header;