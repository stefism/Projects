import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { createPost } from '../actions/postActions';

class Postform extends Component {
    constructor(props) {
        super(props);

        this.state = {
            title: '',
            body: ''
        };

    this.onChange = this.onChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
    }

    onChange(event) {
        this.setState({[event.target.name]: event.target.value})
        //event.target.name -> grab the name of the element which I'm clicked (name="title")
        // and ser him value. The value -> is the text which user writen in the element.
        // in this case, on input lement or text area element.
        // If we don't do this, we won't be able to write anything in the elements.
    }

    onSubmit(event) {
        event.preventDefault();

        const post = {
            title: this.state.title,
            body: this.state.body
        };

        // fetch('https://jsonplaceholder.typicode.com/posts', {
        //     method: 'POST',
        //     headers: {
        //         'content-type': 'application/json'
        //     },
        //     body: JSON.stringify(post)
        // })
        // .then(response => response.json())
        // .then(data => console.log(data));

        this.props.createPost(post);
    }

    render() {
        return (
            <div>
                <h1>Add Post</h1>
                
                <form onSubmit={this.onSubmit}>
                    <label>Title: </label><br/>
                    <input type="text" name="title"
                    onChange={this.onChange}
                    value={this.state.title}/>
                    <br/>

                    <label>Body: </label><br/>
                    <textarea name="body" value={this.state.body}
                    onChange={this.onChange}/>
                    <br/>

                    <button type="submit">Submit</button>
                </form>
            </div>
        )
    }
}

Postform.propTypes = {
    createPost: PropTypes.func.isRequired
};

export default connect(null, { createPost })(Postform);