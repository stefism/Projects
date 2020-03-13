function delimeter(array) {
    let delimeter = array.pop()

    return array.join(delimeter)
}

console.log(delimeter(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
))