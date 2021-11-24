function heroicInventory(input){
    let result = [];
    
    input.forEach(hero => {
        let [name, level, items] = hero.split(" / ");
        let currHero = {
            name: name,
            level: Number(level),
            items: items.split(", ")
        }

        result.push(currHero);
    });

    return JSON.stringify(result);
}

console.log(heroicInventory(
[
'Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara'
]
));