import React, { useReducer, useState } from "react";
import Toolbar from "./Toolbar";
import ThemeContext from "../../Contexts/ThemeContext";

const AdvancedContextApp = () => {
    // const [theme, setTheme] = useState({
    //     color: 'dark',
    //     size: 'normal',
    //     font: 'default'
    // });

    const themeReducer = (state, action) => {
        return {...state, color: action}; //action -> dispatch in ThemedButton.
    }

    const [theme, dispatch] = useReducer(themeReducer, {
        color: 'dark',
        size: 'normal',
        font: 'default'
    });

        return (
            <ThemeContext.Provider value={[theme, dispatch]}>
                <Toolbar />
            </ThemeContext.Provider>
        );
}

export default AdvancedContextApp;