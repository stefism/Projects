function Book(props) {
    return(
        <article>
            <h3 onClick={props.clickHandler}>{props.title}</h3>
            <p>{props.description}</p>
        </article>
    )
}

export default Book;