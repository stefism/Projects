import React from "react"

function SingleLetter(props){
    return(
        <div>         
            <h3 
            id="letter"
            letterId={props.item.id}
            isClicked={props.item.isClicked}
            onClick={() => props.ifClicked()}
            >{props.item.letter} </h3>
        </div>
    )
}

export default SingleLetter