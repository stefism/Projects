import React from "react";

class Days extends React.Component {
    
    componentDidMount(){
        let days = document.getElementsByClassName('react-calendar__month-view__days');
        console.log(days);
    }
}

export default Days