function heroicInventory(data) {
    return JSON.stringify(data.reduce((acc, heroString, i, arr) => {
        let [name, level, items] = heroString.split(' / ')
        acc.push({name, level: Number(level), items: items ? items.split(', '): []})
        return acc
    }, []))
}

console.log(heroicInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
))