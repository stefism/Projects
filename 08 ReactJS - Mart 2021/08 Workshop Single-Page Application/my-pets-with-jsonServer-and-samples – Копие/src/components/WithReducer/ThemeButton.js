import React, { useContext } from "react";
import Button from "./Button";
import ThemeContext from "../../Contexts/ThemeContext";
import HeaderC from "./HeaderC";

const ThemedButton = () => {
    const [theme, dispatch] = useContext(ThemeContext);

    const onChangeThemeClickHandler = () => {
        dispatch(theme.color == 'dark' ? 'light' : 'dark'); //action
    }

        return (
            <>
                <HeaderC />
                <Button theme={theme} buttonClickHandler={onChangeThemeClickHandler} />
            </>
        );    
}

export default ThemedButton;