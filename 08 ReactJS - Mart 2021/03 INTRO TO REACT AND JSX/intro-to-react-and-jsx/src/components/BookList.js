import { Component } from 'react'
import Book from './Book'

class BookList extends Component {
    constructor(props){
        super(props)

        this.state = {
            books: []
        }
    }

    bookClicked(title) {
        console.log(`The book ${title} has been clicked.`);
    }

    render() {
        return (
            <div className='book-list'>
                <h3>Books Collection</h3>
                
                {this.props.books.map(book => {
                    return <Book key={book.id}
                            title={book.title} 
                            description={book.description}
                            clickHandler={() => this.bookClicked(book.title)}/>;
                })}
            </div>
        )
    }
}

export default BookList;