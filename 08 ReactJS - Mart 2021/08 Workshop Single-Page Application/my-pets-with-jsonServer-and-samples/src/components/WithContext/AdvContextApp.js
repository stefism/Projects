import React from "react";
import Toolbar from "./Toolbar";
import ThemeContext from "../../Contexts/ThemeContext";

class AdvancedContextApp extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentTheme: 'dark'
        }
    }

    onChangeThemeClickHandler() {
        this.setState(oldState => ({currentTheme: oldState.currentTheme == 'dark' ? 'light' : 'dark'}));

        // this.setState(oldState => oldState.currentTheme == 'dark' 
        //                 ? {currentTheme: 'light'} 
        //                 : {currentTheme: 'dark'}); // Може и така.
    }

    render() {
        return (
            <ThemeContext.Provider value={
                {
                    theme: this.state.currentTheme,
                    onChangeThemeClickHandler: this.onChangeThemeClickHandler.bind(this)
                }}>
                <Toolbar 
                    // theme={this.state.currentTheme} // Това вече не е нужно, когато ползваме Context
                    // onChangeThemeClickHandler={this.onChangeThemeClickHandler.bind(this)} 
                />
            </ThemeContext.Provider>
        );
    }
}

export default AdvancedContextApp;