import React, { Component } from 'react';
import { connect } from 'react-redux';

class NewComp extends Component {
    styles = {
        fontStyle: 'italic',
        color: 'purple',
    };

    render() {
        return(
            <div className='App'>
                <h2 style={this.styles}>{this.props.message}</h2>
                <button onClick={this.props.ButtonChange}>Click button</button>
            </div>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        message: state.message,
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        ButtonChange: () => dispatch({type: 'Message change'}),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(NewComp);