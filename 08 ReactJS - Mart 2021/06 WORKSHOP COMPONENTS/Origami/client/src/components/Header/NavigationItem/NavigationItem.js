import style from './NavigationItem.module.css';

const NavigationItem = (props) => {
    console.log(props);
    return (
        
        <li className={style.listItem}>
            <span className={style.navListItem}>{props.children}</span>
        </li>
    )
}

export default NavigationItem;