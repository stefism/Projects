import React from "react";

function Header(){
    let firstName = "Stefan";
    let lastName = "Markov";

    return (
        <header>
            <h1 className="header">Hello {`${firstName} ${lastName}`}.</h1>
        </header>
    );
}

export default Header