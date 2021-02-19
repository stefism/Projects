import React, { Component } from 'react'

class Postform extends Component {
    constructor(props) {
        super(props)

        this.state = {
            title: '',
            body: ''
        }
    }

    render() {
        return (
            <div>
                <h1>Add Post</h1>
                
                <form>
                    <label>Title: </label><br/>
                    <input type="text" name="title" value={this.state.title}/><br/>

                    <label>Body: </label><br/>
                    <textarea name="body" value={this.state.body}/><br/>

                    <button type="submit">Submit</button>
                </form>
            </div>
        )
    }
}

export default Postform