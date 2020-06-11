class Rat{
    constructor(name, unitedRats = []) {
        this.name = name
        this.unitedRats = unitedRats
    }

    unite(secondRat){
        if(secondRat.constructor.name === 'Rat' && typeof secondRat === 'object'){
            this.unitedRats.push(secondRat)
        }

        if(secondRat instanceof Rat){
            // Е така е по-готино на горното.
        }
    }

    getRats(){
        return this.unitedRats
    }

    toString(){
        if(this.unitedRats.length > 0){
            let rats = `${this.name}\n`
            this.unitedRats.map(r => rats += `##${r.name}\n`)
            return rats.trim()
        } else {
            return this.name
        }
    }
}

let firstRat = new Rat('Peter')
firstRat.unite(new Rat('George'))
firstRat.unite(new Rat('Ivan'))
firstRat.unite('Stoyan')
console.log(firstRat.toString())
console.log(firstRat.getRats())