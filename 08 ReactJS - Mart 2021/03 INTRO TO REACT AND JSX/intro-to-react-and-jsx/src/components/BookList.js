import { Component } from 'react'
import Book from './Book'

class BookList extends Component {
    constructor(props){
        super(props)
    }

    render() {
        return (
            <div className='book-list'>
                <h3>Books Collection</h3>
                
                {this.props.books.map(book => {
                    return <Book title={book.title} description={book.description}/>;
                })}
            </div>
        )
    }
}

export default BookList;