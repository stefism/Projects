import style from './Header.module.css';
import NavigationItem from './NavigationItem/NavigationItem';
import style2 from './NavigationItem/NavigationItem.module.css';
import { Link, NavLink } from 'react-router-dom';

const Header = () => {
    return (
        <nav className={style.navigation}>
          <ul>
            <li className={style2.listItem}><img width="80px" src="/white-origami-bird.png" alt="white origami"/></li>
            <Link to="/about"><NavigationItem>About</NavigationItem></Link>
            <Link to="/"><NavigationItem>Home</NavigationItem></Link>
            <Link to="/about/edno"><NavigationItem>Going to edno</NavigationItem></Link>
            <Link to="/about/dve"><NavigationItem>Going to dve</NavigationItem></Link>
            <NavLink activeStyle={{backgroundColor: 'red'}} exact={true} to="/about/tri"><NavigationItem>Going to tri</NavigationItem></NavLink>
            <NavLink activeStyle={{backgroundColor: 'red'}} exact={true} to="/about/cetri"><NavigationItem>Going to cetiri</NavigationItem></NavLink>
            <NavLink activeStyle={{backgroundColor: 'red'}} exact={true} to="/about/pet"><NavigationItem>Going to pet</NavigationItem></NavLink>
          </ul>   
        </nav>
    );
};

export default Header;