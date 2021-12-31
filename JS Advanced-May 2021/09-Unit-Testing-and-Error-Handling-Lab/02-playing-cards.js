function playingCards(face, suit) {
    let cardSuits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    let validCardFaces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];

    if(!validCardFaces.includes(face) || cardSuits[suit] == undefined){
        throw Error;
    }

    let cardObject = {
        face: face,
        suit: cardSuits[suit],
        toString: () => {
            return `${face}${cardSuits[suit]}`;
        }
    };

    return cardObject;
}

let card = playingCards('2', 'S');
card.toString();

console.log(card.toString());