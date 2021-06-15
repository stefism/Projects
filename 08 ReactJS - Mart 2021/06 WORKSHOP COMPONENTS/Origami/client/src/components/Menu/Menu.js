import './Menu.css';
import MenuItem from './MenuItem/MenuItem';
import { useState } from 'react';

const menuItems = [
    {id: 1, text: 'Going to 1'},
    {id: 2, text: 'Going to 2'},
    {id: 3, text: 'Going to 3'},
    {id: 4, text: 'Going to 4'},
    {id: 5, text: 'Going to 5'},
    {id: 6, text: 'Going to 6'},
    {id: 7, text: 'Going to 7'},
    {id: 8, text: 'Going to 8'},
    {id: 9, text: 'Going to 9'},
    {id: 10, text: 'Going to 10'},
    {id: 11, text: 'Going to 11'}
];

const Menu = ({onMenuItemClick}) => {
    const [currentItem, setCurrentItem] = useState();

    const menuItemClickHandler = (id) => {
        setCurrentItem(id);
        onMenuItemClick(id);
    }

    return (
        <aside className="menu">
            {menuItems.map(item =>
                <MenuItem 
                    key={item.id} 
                    id={item.id}
                    isSelected={item.id == currentItem}
                    onClick={menuItemClickHandler}>{item.text}
                </MenuItem>
            )}       
        </aside>
    );
}

export default Menu;