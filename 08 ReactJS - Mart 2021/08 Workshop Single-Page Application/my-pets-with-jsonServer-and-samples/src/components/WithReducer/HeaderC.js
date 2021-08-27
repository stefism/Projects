import { useContext } from "react";
import ThemeContext from "../../Contexts/ThemeContext";

const HeaderC = () => {
    const [ theme ]  = useContext(ThemeContext); //Взимаме си от контекста само пропертито, което ни интересува.

    return (
        <header style={{color: theme.color == 'dark' ? 'darkgray' : 'lightgreen'}}>
            <h1>Some Cool Header Here</h1>
            <p>Стъклотапетът се поставя от горе надолу. Голяма част от участниците в проучването смятат, че реформата в БАН трябва да започне от горе надолу.</p>
        </header>
    )
}

export default HeaderC;