function buildPyramid(base, increment) {
    let stone = 0, gold = 0, marble = 0, lapis = 0, height = 1;
    while (base > 0) {
        if (base < 3) {
            tempGold = base * base;
            gold += tempGold * increment;
        }
        else if (height % 5 == 0) {
            let tempStone = (base - 2) * (base - 2);
            let tempLapis = (base * base) - tempStone;
            stone += tempStone * increment;
            lapis += tempLapis * increment;
        }
        else {
            let tempStone = (base - 2) * (base - 2);
            let tempMarble = (base * base) - tempStone;
            stone += tempStone * increment;
            marble += tempMarble * increment;
        }
        height++;
        base -= 2;
    }

    console.log("Stone required: " + Math.ceil(stone));
    console.log("Marble required: " + Math.ceil(marble));
    console.log("Lapis Lazuli required: " + Math.ceil(lapis));
    console.log("Gold required: " + Math.ceil(gold));
    console.log("Final pyramid height: " + Math.floor((height - 1) * increment));
}

buildPyramid(11, 1);
console.log("--------------------------------------");
buildPyramid(11, 0.75);
console.log("--------------------------------------");
buildPyramid(23, 0.5);
console.log("--------------------------------------");
buildPyramid(5000, 1);