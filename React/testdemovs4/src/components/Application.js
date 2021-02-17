import { render } from "@testing-library/react";
import React from "react";

import TodoItem from "./TodoItem";
import todosData from "./TodosData";

import "../style.css";

class Application extends React.Component {
    constructor(){
        super();
        this.state = {
            todos: todosData,
            loading: false,
            firstName: "",
            lastName: "",
            isFrendly: true,
            gender: "",
            favColor: "blue",
            character: {}
        }

        this.HandleChange = this.HandleChange.bind(this)
        this.handleChange2 = this.handleChange2.bind(this)
    }

    componentDidMount(){
        this.setState({loading: true})
        fetch("https://api.github.com/users/stefism")
        .then(response => response.json())
        .then(data => {
            this.setState({
                loading: false,
                character: data
            })
        })
    }

    HandleChange(id){
        this.setState((prevState) => {
            let updatedTodos = prevState.todos.map(todo => {
                if (todo.id === id){
                    todo.completed = !todo.completed
                }
                return todo
            })
            return {
                todos: updatedTodos
            }
        });
    }

    handleChange2(event){
        let {name, value, type, checked} = event.target
        type === "checkbox" 
        ? this.setState({[name]: checked})
        : this.setState({[name]: value})
        }
    
    render() {
        let todoItems = this.state.todos.map(item => <TodoItem
            key={item.id}
            item={item}
            handleChange={this.HandleChange}/>);

            // if(this.state.loading){
            //     return (
            //         <h1>Loading ...</h1>
            //     )
            // }
    
            return(
                <div>

                    <div className="todo-list">
                    {todoItems}
                    </div>

                    <form onSubmit={this.handleSubmit}>
                        <input 
                        type="text" 
                        value={this.state.firstName}
                        name="firstName" 
                        placeholder="First Name" 
                        onChange={this.handleChange2} />

                        <input 
                        type="text" 
                        value={this.state.lastName}
                        name="lastName" 
                        placeholder="Last Name"     
                        onChange={this.handleChange2} />

                        <textarea 
                        value={"Some default value"}
                        onChange={this.handleChange2} 
                        />

                        <label>
                        <input 
                            type="checkbox"
                            name="isFrendly"
                            checked={this.state.isFrendly}
                            onChange={this.handleChange2} 
                            />Is friendly?
                        </label>
                        <br />
                        <label>
                        <input 
                            type="radio"
                            name="gender"
                            value="male"
                            checked={this.state.gender === "male"}
                            onChange={this.handleChange2} 
                            />Male
                        </label>

                        <label>
                        <input 
                            type="radio"
                            name="gender"
                            value="female"
                            checked={this.state.gender === "female"}
                            onChange={this.handleChange2} 
                            />Female
                        </label>
                        <br/>
                        <label>Favorite color:</label>
                        <select 
                        value={this.state.favColor}                   
                        onChange={this.handleChange2}
                        name="favColor"
                        >
                            <option value="blue">Blue</option>
                            <option value="green">Green</option>
                            <option value="red">Red</option>
                        </select>
  
                        <h1>{this.state.firstName} {this.state.lastName}</h1>
                        <h2>You are a {this.state.gender}</h2>
                        <h2>You favorite color is {this.state.favColor}</h2>

                        <button>Submit</button>
                    </form>

                    <hr/>

                    <h4>{this.state.character.name}</h4>
                    <p>{this.state.character.bio}</p>
                
                </div>
                
            )
    }
}

export default Application