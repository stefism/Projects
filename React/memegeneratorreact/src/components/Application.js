import React from "react"

import Header from "./Header"
import MemeGenerator from "./MemeGenerator"

import "../style.css"

function Application(){
    return(
        <div>
            <Header/>
            <MemeGenerator/>
        </div>
    )
}

export default Application