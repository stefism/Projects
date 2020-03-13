function ticTacToe(coordinates) {
    let dashBoard = [
        ['false', 'false', 'false'],
        ['false', 'false', 'false'],
        ['false', 'false', 'false']
    ]

    for (let i = 0; i < coordinates.length; i++) {
        if(i % 2 == 0){ //first player
            if(noWins(dashBoard)){
                return 'The game ended! Nobody wins :('
            }

            let firstPlayerRow = Number(coordinates[i][0])
            let firstPlayerCol = Number(coordinates[i][2])

            if(dashBoard[firstPlayerRow][firstPlayerCol] !== 'false'){
                console.log('This place is already taken. Please choose another!')
                i--
                continue
            }

            dashBoard[firstPlayerRow][firstPlayerCol] = 'X'
        }
    }

    function noWins(dashBoard) {
        if(!dashBoard[0].includes('false') && !dashBoard[1].includes('false') && !dashBoard[2].includes('false')){
            return true
        } else {
            return false
        }
    }
}

console.log(ticTacToe(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
))