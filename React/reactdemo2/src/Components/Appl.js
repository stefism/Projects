import React from "react";

import Header from "./Header";
import Footer from "./Footer";
import MainContent from "./MainContent";

import "../style.css";

function Appl(){
    return(
        <div>
            <Header />
            <MainContent />
            <Footer />
        </div>
    );
}

export default Appl