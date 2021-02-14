import React from 'react';
import ReactDOM from 'react-dom';

import MyInfo from "./components/MyInfo";
import UnorderedList from "./components/UnorderedList";
import App from "./components/App";

ReactDOM.render(<App />, document.getElementById("root"));

ReactDOM.render(
    <MyInfo />, document.getElementById("myInfo")
);

ReactDOM.render(
    <UnorderedList />,
    document.getElementById("ul")
);