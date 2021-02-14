import React from "react";

class Header extends React.Component {
    render() {
        let firstName = "Stefan";
        let lastName = "Markov";

        return (
            <header>
                <h1 className="header">Hello {`${firstName} ${this.props.middleName} ${lastName}`}.</h1>
            </header>
        );
    }
}

export default Header