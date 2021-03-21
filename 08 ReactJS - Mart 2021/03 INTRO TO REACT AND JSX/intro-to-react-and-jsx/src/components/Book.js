import style from './Book.module.css';

function Book(props) {
    return(
        <article className={style.article}>
            <h3 className={style.h3} onClick={props.clickHandler}>{props.title}</h3>
            <p className={style.p}>{props.description}</p>
        </article>
    )
}

export default Book;