function solve(primary, secondary, overlay, start) {
    secondaryCols = secondary[0].length;
    secondaryRows = secondary.length;
    for (let c in overlay) {
        let coordinates = overlay[c];
        if (coordinates[0] <= primary.length - 1) {
            if (coordinates[1] <= primary[coordinates[0]].length - 1) {
                let row = 0;
                for (let i = coordinates[0]; row < secondaryRows; i++) {
                    if (i > primary.length - 1) break;
                    let col = 0;
                    for (let j = coordinates[1]; col < secondaryCols; j++) {
                        if (j > primary[i].length - 1) break;
                        if (primary[i][j] == secondary[row][col]) primary[i][j] = 0;
                        else primary[i][j] = 1;
                        col++;
                    }
                    row++;
                }
            }
        }
    }

    let a = start[0];
    let b = start[1];
    let prevB = - 1, prevA = -1, steps = 1;
    while (true) {
        if (a == primary.length - 1 && primary[a][b] == 0 && steps > 1) {
            console.log(steps + '\nBottom');
            break;
        }
        else if (b == primary[a].length - 1 && primary[a][b] == 0 && steps > 1) {
            console.log(steps + '\nRight');
            break;
        }
        else if (a == 0 && primary[a][b] == 0 && steps > 1) {
            console.log(steps + '\nTop');
            break;
        }
        else if (b == 0 && primary[a][b] == 0 && steps > 1) {
            console.log(steps + '\nLeft');
            break;
        }
        if (primary[a + 1][b] == 0 && a + 1 != prevA) {
            prevA = a;
            a++;
            steps++;
            prevB = -1;
        }
        else if (primary[a - 1][b] == 0 && a - 1 != prevA) {
            prevA = a;
            a--;
            steps++;
            prevB = -1;
        }
        else if (primary[a][b + 1] == 0 && b + 1 != prevB) {
            prevB = b;
            b++;
            steps++;
            prevA = -1;
        }
        else if (primary[a][b - 1] == 0 && b - 1 != prevB) {
            prevB = b;
            b--;
            steps++;
            prevA = -1;
        }
        else {
            console.log(steps);
            let quad = 0;
            if (a + 1 <= primary.length / 2 && b + 1 > primary[a].length / 2) quad = 1;
            else if (a + 1 <= primary.length / 2 && b + 1 <= primary[a].length / 2) quad = 2;
            else if (a + 1 > primary.length / 2 && b + 1 <= primary[a].length / 2) quad = 3;
            else if (a + 1 > primary.length / 2 && b + 1 > primary[a].length / 2) quad = 4;
            console.log('Dead end ' + quad);
            break;
        }
    }
}

solve([[1, 1, 0, 1, 1, 1, 1, 0],
[0, 1, 1, 1, 0, 0, 0, 1],
[1, 0, 0, 1, 0, 0, 0, 1],
[0, 0, 0, 1, 1, 0, 0, 1],
[1, 0, 0, 1, 1, 1, 1, 1],
[1, 0, 1, 1, 0, 1, 0, 0]],
    [[0, 1, 1],
    [0, 1, 0],
    [1, 1, 0]],
    [[1, 1],
    [2, 3],
    [5, 3]],
    [0, 2]);

solve([[1, 1, 0, 1],
[0, 1, 1, 0],
[0, 0, 1, 0],
[1, 0, 1, 0]],
    [[0, 0, 1, 0, 1],
    [1, 0, 0, 1, 1],
    [1, 0, 1, 1, 1],
    [1, 0, 1, 0, 1]],
    [[0, 0],
    [2, 1],
    [1, 0]],
    [2, 0]);