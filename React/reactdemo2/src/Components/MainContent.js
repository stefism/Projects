import React from "react";

function MainContent(){
    let date = new Date();
    let hours = date.getHours();
    let timeOfDay;

    if (hours < 12){
        timeOfDay = "morning";
    } else if(hours >= 12 && hours < 17){
        timeOfDay = "afternoon";
    } else {
        timeOfDay = "night";
    }

    let style = {
        color: "blue",
        "font-weight": "bold",
        "font-size": "22px",
    };

    return(
        <main>
            <p>Main text element is here.</p>
            <p>Today is {date.getDay()}-th of the week.</p>
            <p style={style}>Good {timeOfDay}.</p>
        </main>
    );
}

export default MainContent