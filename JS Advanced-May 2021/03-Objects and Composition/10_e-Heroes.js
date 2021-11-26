function heroes(){
    let heroes = {
        create: {
            mage: createMage(mageName),
            fighter: createFighter(fighterName)
        }
    }

    return heroes;

    function createMage(mageName){
        let mage = {
            mageName,
            health: 100,
            mana: 100,
            cast: function(spell){
                this.mana--;
                console.log(`${this.mageName} cast ${spell}`);
            }
        }

        return mage;
    }

    function createFighter(fighterName){
        let fighter = {
            fighterName,
            health: 100,
            stamina: 100,
            fight: function() {
                this.stamina--;
                console.log(`${this.fighterName} slashes at the foe!`);
            }
        }

        return fighter;
    }
}

let create = heroes();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);