function pieceOfPie(arrayOfIngredients, firstIngredient, lastIngredient){
    let firstIndex = arrayOfIngredients.indexOf(firstIngredient);
    let secondIndex = arrayOfIngredients.indexOf(lastIngredient);

    let ingredients = arrayOfIngredients.slice(firstIndex, secondIndex + 1);

    return ingredients;
}

let findedIngredients = pieceOfPie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie');

console.log(findedIngredients);