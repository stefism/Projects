function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            
            this.ribbonColor = ribbonColor;
            this.ribbonLength = ribbonLength;
        }

        get ribbon() {
            return {
                color: this.ribbonColor,
                length: this.ribbonLength
            }
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);

            this.text = text;
        }

        get text() {
            return this._text;
        }

        set text(value) {
            this._text = value;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}

let classes = solve();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5, "red", 10.25);
let birth = new classes.BirthdayBalloon("yellow", 20.5, "red", 10.25, 'Test test');
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon);
console.log(birth.text);
