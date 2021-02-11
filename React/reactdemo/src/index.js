import React from 'react';
import ReactDOM from 'react-dom';

import MyInfo from "./components/MyInfo";
import UnorderedList from "./components/UnorderedList";

ReactDOM.render(<h1>Hello world!</h1>, document.getElementById("root"));

ReactDOM.render(
    <MyInfo />, document.getElementById("myInfo")
);

ReactDOM.render(
    <UnorderedList />,
    document.getElementById("ul")
);