import React from "react"

function TodoItem(props){
    let completedStyle = {
        fontStyle: "italic",
        color: "#cdcdcd",
        textDecoration: "line-through"
    }

    return (
      <div className="todo-item">
          <input
              type="checkbox"
              checked={props.item.completed}
              onChange={() =>
                  props.handleChange(props.item.id)}/>

              <p style={props.item.completed ? completedStyle: null}>{props.item.text}</p>
              {/* If props.item.completed === true -> apply completedStyle, else apply none */}
      </div>
    );
};

export default TodoItem