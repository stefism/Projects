import React from "react";
// Това е без да ползваме контекст. С подаване ръчно на пропертитата на долу.
class AdvancedApp extends React.Component {
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
        return <Toolbar theme={this.state.currentTheme} 
                onChangeThemeClickHandler={this.onChangeThemeClickHandler.bind(this)} />;
    }
}

function Toolbar(props) {
    return (
        <div>
            <ThemedButton theme={props.theme} 
             onChangeThemeClickHandler={props.onChangeThemeClickHandler} />
        </div>

    );
}

class ThemedButton extends React.Component {
    render() {
        return <Button theme={this.props.theme} 
                buttonClickHandler={this.props.onChangeThemeClickHandler} />;
    }    
}

function Button({theme, buttonClickHandler}) {
    return (
        <button 
            onClick={buttonClickHandler}
            style={{backgroundColor: theme == 'dark' ? 'darkgray' : 'lightgreen'}}>
            {theme}
        </button>
    )
}

export default AdvancedApp;