function solve(input, battles) {
    let kingdoms = new Map();
    let sortedKingdoms = [];
    let sortedGenerals = [];
    let kingd = [];
    let kingg = [];

    for (let k in input) {
        if (!kingdoms.has(input[k].kingdom)) {
            kingdoms.set(input[k].kingdom, new Map());
            kingd.push(input[k].kingdom);
        }
        if (!kingdoms.get(input[k].kingdom).has(input[k].general)) {
            let army = { capacity: Number(input[k].army), wins: Number(0), losses: Number(0) };
            kingdoms.get(input[k].kingdom).set(input[k].general, army);
            let general = { kingdom: input[k].kingdom, general: input[k].general };
            kingg.push(general);
        }
        else {
            let currentArmy = kingdoms.get(input[k].kingdom).get(input[k].general);
            currentArmy.capacity += input[k].army;
            kingdoms.get(input[k].kingdom).set(input[k].general, currentArmy);
        }
    }

    for (let i = 0; i < battles.length; i++) {
        if (battles[i][0] == battles[i][2])
            continue;
        else {
            let armyOne = kingdoms.get(battles[i][0]).get(battles[i][1]);
            let armyTwo = kingdoms.get(battles[i][2]).get(battles[i][3]);
            if (armyOne.capacity > armyTwo.capacity) {
                armyOne.capacity = Math.trunc(armyOne.capacity * 1.1);
                armyOne.wins++;
                kingdoms.get(battles[i][0]).set(battles[i][1], armyOne);
                armyTwo.capacity = Math.trunc(armyTwo.capacity * 0.9);
                armyTwo.losses++;
                kingdoms.get(battles[i][2]).set(battles[i][3], armyTwo)
            }
            else if (armyTwo.capacity > armyOne.capacity) {
                armyOne.capacity = Math.trunc(armyOne.capacity * 0.9);
                armyOne.losses++;
                kingdoms.get(battles[i][0]).set(battles[i][1], armyOne);
                armyTwo.capacity = Math.trunc(armyTwo.capacity * 1.1);
                armyTwo.wins++;
                kingdoms.get(battles[i][2]).set(battles[i][3], armyTwo)
            }
            else continue;
        }
    }

    for (let k in kingd) {
        kingdomWins = 0;
        kingdomLosses = 0;
        for (let g in kingg) {            
            if (kingd[k] == kingg[g].kingdom) {
                let winsLosses = kingdoms.get(kingd[k]).get(kingg[g].general);
                kingdomWins += winsLosses.wins;
                kingdomLosses += winsLosses.losses;
            }            
        }
        sortedKingdoms.push({ kingdom: kingd[k], wins: kingdomWins, losses: kingdomLosses });
    }

    sortedKingdoms.sort(compareKingdoms);

    for (let g in kingg) {
        if (sortedKingdoms[0].kingdom == kingg[g].kingdom) {
            let general = kingdoms.get(sortedKingdoms[0].kingdom).get(kingg[g].general);
            sortedGenerals.push({ general: kingg[g].general, army: general.capacity });
        }
    }

    sortedGenerals.sort(compareGenerals);
    let winnerGenerals = kingdoms.get(sortedKingdoms[0].kingdom);

    console.log('Winner: ' + sortedKingdoms[0].kingdom);
    for (let gen in sortedGenerals) {
        console.log('/\\general: ' + sortedGenerals[gen].general);
        let army = kingdoms.get(sortedKingdoms[0].kingdom).get(sortedGenerals[gen].general);
        console.log('---army: ' + army.capacity);
        console.log('---wins: ' + army.wins);
        console.log('---losses: ' + army.losses);
    }
    
    function compareGenerals(a, b) {
        if (a.army < b.army) return 1;
        if (a.army > b.army) return -1;        
        return 0;
    }

    function compareKingdoms(a, b) {
        if (a.wins < b.wins) return 1;
        if (a.wins > b.wins) return -1;
        if (a.wins == b.wins) {
            if (a.losses < b.losses) return -1;
            if (a.losses > b.losses) return 1;
            if (a.losses == b.losses) {
                var nameA = a.kingdom.toLowerCase(), nameB = b.kingdom.toLowerCase();
                if (nameA < nameB) return -1;
                if (nameA > nameB) return 1;
            }
            return 0;
        }
        return 0;
    }
}

solve([{ kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Stonegate", "Ulric", "Stonegate", "Doran"],
    ["Stonegate", "Doran", "Maiden Way", "Merek"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
    ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]);