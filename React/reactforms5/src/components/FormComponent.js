import React from "react"

function FormComponent(props){
    return(
        <main>
            <form>                    
                <input 
                    name="firstName" 
                    value={props.data.firstName}
                    onChange={props.handleChange}
                    placeholder="First Name" /> <br/>

                <input 
                    name="lastName" 
                    value={props.data.lastName}
                    onChange={props.handleChange}
                    placeholder="Last Name" /> <br/>

                <input 
                    name="age" 
                    value={props.data.age} 
                    onChange={props.handleChange}
                    placeholder="Age" /> <br/>

                <label>
                    <input type="radio" name="gender" value="male"
                    checked={props.data.gender === "male"}
                    onChange={props.handleChange}/> Male
                </label>

                <label>
                    <input type="radio" name="gender" value="female"
                    checked={props.data.gender === "female"}
                    onChange={props.handleChange}/> Female
                </label>
                <br />
                <select 
                    value={props.data.destination}
                    name="destination"
                    onChange={props.handleChange}
                    >
                    
                    <option value="">Choose a destination</option>
                    <option value="germany">Germany</option>
                    <option value="france">France</option>
                    <option value="spain">Spain</option>
                    <option value="portugal">Portugal</option>
                </select>
                <br/>

                <label>
                    <input 
                    type="checkbox" 
                    name="isVegan"
                    onChange={props.handleChange}
                    checked={props.data.isVegan}
                    /> Vegan?
                </label>

                <label>
                    <input 
                    type="checkbox" 
                    name="isKosher"
                    onChange={props.handleChange}
                    checked={props.data.isKosher}
                    /> Kosher?
                </label>

                <label>
                    <input 
                    type="checkbox" 
                    name="isLacroseFree"
                    onChange={props.handleChange}
                    checked={props.data.isLacroseFree}
                    /> Lactose?
                </label>

                <br/>
                <button>Submit</button>
            </form>
            <hr/>
            <h2>Entered information:</h2>
            <p>Your name: {props.data.firstName} {props.data.lastName}</p>
            <p>Your age: {props.data.age}</p>
            <p>Your gender: {props.data.gender}</p>
            <p>Your destination: {props.data.destination}</p>
            <h4>Your dietary restrictions:</h4>
            <p>Vegan: {props.data.isVegan ? "Yes" : "No"}</p>
            <p>Kosher: {props.data.isKosher ? "Yes" : "No"}</p>
            <p>Lactose Free: {props.data.isLacroseFree ? <b>Yes</b> : "No"}</p>
        </main>
    )
}

export default FormComponent