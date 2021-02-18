import React from "react"

function SingleLetter(props){
    let clickedStyle = {
        color: "blue",
        cursor: "default"
    }

    return(
        <div>         
            <h3 
            class="letter"
            style={props.item.isClicked ? clickedStyle : null}
            onClick={() => props.ifClicked(props.item.id, props.item.letter)}
            >{props.item.letter} </h3>
        </div>
    )
}

export default SingleLetter