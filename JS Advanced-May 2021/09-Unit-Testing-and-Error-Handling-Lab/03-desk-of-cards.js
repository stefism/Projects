function createCard(array) {
    let cardSuits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    let validCardFaces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];

    let result = [];

    let isError = false;

    array.forEach(e => {
        let face;
        let suit;

        if(e.length == 3){
            face = e[0] + e[1];
            suit = e[2];
        } else {
            face = e[0];
            suit = e[1];
        }
        
        result.push(`${face}${cardSuits[suit]}`);

        if(!validCardFaces.includes(face) || cardSuits[suit] == undefined){
            console.log(`Invalid card: ${e}`);
            isError = true;
        }
    });

    if(!isError) {
        console.log(result.join(' '));
    }
}

createCard(['AS', '10D', 'KH', '2C']);