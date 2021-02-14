import React from "react";

class App extends React.Component {
    constructor() {
        super();
        this.state = {
            answer: "Yes",
            count: 0
        }

        this.ChangeState = this.ChangeState.bind(this)
    }

    ChangeState(){

        this.setState((prevState) => {
            return {
                count: prevState.count + 1
            }
        })
    }

    render() {
        return(
            <div>
                <nav>
                    <h1>Is state important to know? - {this.state.answer}</h1>
                    <ul>
                        <li>Thing {this.state.count}</li>
                        <li>Thing 2</li>
                        <li>Thing 3</li>
                    </ul>
                </nav>
                <button onClick={this.ChangeState}>Change</button>
            </div>
        )
    }
}

export default App