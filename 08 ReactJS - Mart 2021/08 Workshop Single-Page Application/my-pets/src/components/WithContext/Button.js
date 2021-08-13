function Button({theme, buttonClickHandler}) {
    return (
        <button 
            onClick={buttonClickHandler}
            style={{backgroundColor: theme == 'dark' ? 'darkgray' : 'lightgreen'}}>
            {theme}
        </button>
    )
}

export default Button;