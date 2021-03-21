import { Component } from 'react';
import refreshComponent from '../hoc/refreshComponent';
import Message from './Message';

class Footer extends Component {
    constructor(props) {
        super(props)

        // this.state = {
        //     showFooter: true
        // };
    }

    // componentDidMount() {
    //     setTimeout(() => {
    //         this.setState({showFooter: false})
    //     }, 2000)
    // }

    // Махнали сме закоментираните неща, за да покажем как работят HOC - High Ordered Component
    
    render() {
        console.log(this.props.refreshCount);
        return (this.props.refreshCount == 0) ? <Message text='All rights reserved &copy;'/> : null
    }
}

// const enchancedFooter = refreshComponent(Footer); //refreshComponent is HOC.
// export default enchancedFooter;

export default refreshComponent(Footer);