function solve() {
    let productsAndPrices = {}

    let finalPrice = 0

    let addButtons = document.getElementsByClassName('product-add')
    Array.from(addButtons).map(b => b.addEventListener('click', b => shoppingCard(b)))

    let textArea = document.getElementsByTagName('textarea')[0]

    let checkout = document.getElementsByClassName('checkout')[0]
    checkout.addEventListener('click', printFinalSumAndDisableButtons)

    function shoppingCard(button) {

        let productName = button.path[2]
            .getElementsByClassName('product-title')[0]
            .innerText

        let productPrice = +button.path[2]
            .getElementsByClassName('product-line-price')[0]
            .innerText

        textArea.innerHTML += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`

        addProduct(productName, productPrice)
    }

    function addProduct(product, price) {
        if(!productsAndPrices.hasOwnProperty(product)){
            productsAndPrices[product] = 0
        }

        productsAndPrices[product] += price
        finalPrice += price
    }

    function printFinalSumAndDisableButtons() {
        let productNames = Object.keys(productsAndPrices)

        textArea.innerHTML += `You bought ${productNames.join(', ')} for ${finalPrice.toFixed(2)}.`

        let buttons = document.getElementsByTagName('button')

        for (b of buttons){
            b.disabled = true
        }
    }
}