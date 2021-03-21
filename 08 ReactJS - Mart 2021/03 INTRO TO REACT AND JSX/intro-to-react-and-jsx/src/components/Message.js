import { Component } from 'react';

class Message extends Component {
    constructor(props) {
        super(props)

        console.log('Constructor');

        this.state = {
            company: 'Sirius'
        }
    }

    componentDidMount() {
        console.log('componentDidMount');

        setTimeout(() => {
            // this.forceUpdate(); // Not recomended to use.

            this.setState({company: 'Sirius Software'});
        }, 1500);
    }

    componentDidUpdate() {
        console.log('componentDidUpdate');
    }

    componentWillUnmount() {
        console.log('componentWillUnmount');
    }

    render() {
        console.log('Render');
        return <span>{this.props.text} | {this.state.company}</span>
    }
}

export default Message;