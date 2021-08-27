import React from "react";
import Button from "./Button";
import ThemeContext from "../../Contexts/ThemeContext";
import HeaderC from "./HeaderC";

class ThemedButton extends React.Component {
    render() {
        return (
        <>
        <HeaderC />
        <Button 
                theme={this.context.theme}
                buttonClickHandler={this.context.onChangeThemeClickHandler}
                // theme={this.props.theme}
                // buttonClickHandler={this.props.onChangeThemeClickHandler} 
                />
        
        </>
        );
    }    
}

ThemedButton.contextType = ThemeContext;

export default ThemedButton;