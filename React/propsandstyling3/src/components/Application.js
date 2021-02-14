import React from "react"

import Joke from "./Joke";
import jokesData from "./JokesData";
import Product from "./Product";
import ProductsData from "./ProductsData";

function Application(){
   let jokeComponents = jokesData.map(joke =>
       <Joke key={joke.id}
             question={joke.question}
             answer={joke.answer} />);

   let productComponents = ProductsData.map(item =>
       <Product key={item.id}
                element={item} />);

    return (
        <div>
            {jokeComponents}
            <hr/>
            {productComponents}
        </div>
    )
}

export default Application