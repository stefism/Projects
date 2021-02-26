import React, { Component } from 'react';

class Authenticate extends Component {
    constructor(props){
        super(props);

       this.state = {
        user: undefined
       } 
    }

    render() {
        return (
            <div>
                This is authenticate page.
            </div>
        )
    }
}

export default Authenticate