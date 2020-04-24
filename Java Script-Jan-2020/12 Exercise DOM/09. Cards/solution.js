function solve() {
    let player1Div = document.getElementById('player1Div').children
    //debugger

    let playerOneCard = Array.from(player1Div).map(card => card
        .addEventListener('click', card => card.target))
    debugger
}