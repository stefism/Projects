import React from "react";

import Header from "./Header";
import Footer from "./Footer";
import MainContent from "./MainContent";
import TodoItem from "./TodoItem";
import ContactCard from "./ContactCard";

import "../style.css";

function Appl(){
    return(
        <div>
            <Header />
            <MainContent />
            <div className="contacts">

                <ContactCard
                    contact={{
                        name: "Mr. Cat 1",
                        imgUrl: "http://placekitten.com/300/200",
                        phone: "4511-556-656",
                        email: "tree@cat.com"
                    }}
                />

                <ContactCard
                    contact={{
                        name: "Mr. Cat 2",
                        imgUrl: "http://placekitten.com/300/300",
                        phone: "5689-123-656",
                        email: "one@cat.com"
                    }}
                />

                <ContactCard
                    contact={{
                        name: "Mr. Cat 3",
                        imgUrl: "http://placekitten.com/300/100",
                        phone: "146-556-656",
                        email: "duo@cat.com"
                    }}
                />

            </div>
            <div className="todo-list">
                <TodoItem />
                <TodoItem />
                <TodoItem />
            </div>
            <Footer />
        </div>
    );
}

export default Appl