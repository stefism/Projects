// Функция за селектиране на определено нещо от масив.

function select(arr, query) {
    return arr.filter(value => {
        return value.toLowerCase()
            .indexOf(query.toLowerCase()) !== -1
    })
}
// Ще вземе велюто (value) на нашия масив, ще го направи с малки букви,
// след това ще провери дали вътре в него не се съдържа нашата
// заявка (query) с малки букви.
// Ако се съдържа (заявката, която сме подали) ще върне true или различно от -1.
// Ако не се съдържа ще върне false защото ще бъде равно на -1.
// Преминава през всеки елемент на масива (value-то) и го проверява дали отговаря на даденото условие.

let arr = ['proba', 'stefan', 'stenli', 'ivan', 'stendap']

console.log(select(arr, 'ste'))