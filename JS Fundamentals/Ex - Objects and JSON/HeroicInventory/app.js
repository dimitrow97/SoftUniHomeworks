function heroicInv(input) {
    let heroData = [];
    for (let i = 0; i < input.length; i++) {
        let temp = input[i].split(' / ');
        let currHeroName = temp[0];
        let currHeroLvl = Number(temp[1]);
        let currHeroItems = [];
        if(temp.length > 2)
            currHeroItems = temp[2].split(/\W+/g);

        let newHero = { name: currHeroName, level: currHeroLvl, items: currHeroItems };
        heroData.push(newHero);
    }
    console.log(JSON.stringify(heroData));
}

heroicInv(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword', 'Hes / 1 / Desolator, Sentinel, Antara']);
