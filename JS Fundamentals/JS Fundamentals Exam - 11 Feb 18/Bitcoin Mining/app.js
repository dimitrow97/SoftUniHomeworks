function solve(input) {
    let totalMoney = 0.0;
    let bitcoins = 0;
    let dayOfFirst = 0;
    for (let i = 1; i <= input.length; i++) {
        let gold = 0.0;
        let moneyToday = 0.0;
        if (i % 3 == 0) {
            gold = parseFloat(input[i-1]);
            gold = gold * 0.7;
        }
        else gold = parseFloat(input[i-1]);
        moneyToday = gold * 67.51;
        totalMoney += moneyToday;
        if (totalMoney >= 11949.16) {
            while (totalMoney >= 11949.16) {
                bitcoins++;
                totalMoney -= 11949.16;
            }
            if (dayOfFirst == 0) dayOfFirst = i;
        }
    }

    console.log('Bought bitcoins: ' + bitcoins);
    if(dayOfFirst != 0)
        console.log('Day of the first purchased bitcoin: ' + dayOfFirst);
    console.log('Left money: ' + totalMoney.toFixed(2) + ' lv.');
}

solve(['100', '200', '300']);
console.log(' -------------');
solve(['3124.15', '504.212', '2511.124']);
