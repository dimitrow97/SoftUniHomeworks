function solve(input) {
    let yeild = parseInt(input);
    let days = 0, spice = 0;

    while (yeild >= 100) {
        spice += (yeild - 26);
        yeild -= 10;
        days++;
    }

    console.log(days);
    if (spice >= 26)
        console.log(spice - 26);
    else console.log(0);
}

solve(['111']);
solve(['450']);
solve(['200']);
solve(['0']);