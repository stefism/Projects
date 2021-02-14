import React from "react";

function Product(props){
    return(
        <div>
            <h2>{props.element.name}</h2>
            <p>{props.element.price}</p>
            <p>{props.element.description}</p>
        </div>
    );
}

export default Product