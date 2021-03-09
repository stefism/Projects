import { Component } from 'react';

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 11
        }
    }

    render() {
        return (
            <div>
                <h4>Book Counter</h4>
                <button onClick={() => 
                    this.setState((oldState) => ({count: oldState.count - 1}))}>-</button>
                {/* Ако искаме да се ъпдейтне стейта веднага, ползваме горното. */}
                <span> {this.state.count} </span>

                <button onClick={(event) => 
                    this.setState({count: this.state.count + 1})}>+</button>
            </div>
        );
    }
}

export default Counter;