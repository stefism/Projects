import ThemedButton from "./ThemeButton";

function Toolbar(props) {
    return (
        <div>
            <ThemedButton 
                // theme={props.theme} // И той вече не подава темата надолу.
                // onChangeThemeClickHandler={props.onChangeThemeClickHandler} 
             />
        </div>
    );
}

export default Toolbar;