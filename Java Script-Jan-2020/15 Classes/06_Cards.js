let result = (function(){
    let Suits = {
    SPADES: '♠',
    HEARTS: '♥',
    DIAMONDS: '♦',
    CLUBS: '♣'
}

    let faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"]

    class Card{
        constructor(face, suit) {
            this.face = face
            this.suit = suit
        }

        get face (){
            return this.innerFace
        }

        get suit(){
            return this.innerSuit
        }

        set face(f){
            if(faces.includes(f.toString())){
                this.innerFace = f
            } else {
                throw new Error('Invalid face name.')
            }
        }

        set suit(s){
            if(Object.values(Suits).includes(s)){
                this.innerSuit = s
            } else {
                throw new Error('Invalid suit name.')
            }
        }
    }

    return {
        Suits: Suits,
        Card: Card
    }
}())

let Card = result.Card
let Suits = result.Suits

let card = new Card('Q', Suits.CLUBS)
card.face = 'A'
card.suit = Suits.DIAMONDS

let card2 = new Card('2', Suits.CLUBS)

console.log(card2)
