import React from "react";

function MainContent(){
    let date = new Date();
    let hours = date.getHours();
    let timeOfDay;

    let style = {
        "font-weight": "bold",
        "font-size": "22px",
    };

    if (hours < 12){
        timeOfDay = "morning";
        style.color = "green";
    } else if(hours >= 12 && hours < 17){
        timeOfDay = "afternoon";
        style.color = "red";
    } else {
        timeOfDay = "night";
        style.color = "blue";
    }

    return(
        <main>
            <p>Main text element is here.</p>
            <p>Today is {date.getDay()}-th of the week.</p>
            <p style={style}>Good {timeOfDay}.</p>
        </main>
    );
}

export default MainContent