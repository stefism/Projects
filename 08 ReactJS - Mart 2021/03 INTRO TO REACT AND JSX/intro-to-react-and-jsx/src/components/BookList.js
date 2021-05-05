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

    componentDidMount() {
        fetch('http://localhost:3000/books')
        .then(response => response.json())
        .then(books => {
            this.setState(() => ({books}))
        });
    }

    render() {
        if(this.state.books.length == 0) {
            return <span>Loading books ...</span>
        }

        return (
            <div className='book-list'>
                <h3>Books Collection</h3>
                
                {this.state.books.map(book => {
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