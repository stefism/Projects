import React from "react"

function SingleLetter(props){
    return(
        <div>         
            <h3 
            class="letter"
            onClick={() => props.ifClicked(props.item.id)}
            >{props.item.letter} </h3>
        </div>
    )
}

export default SingleLetter