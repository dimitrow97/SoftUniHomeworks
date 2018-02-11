function solve(input, commands) {
    let matrix = [];
    for (let i = 0; i < 5; i++) {
        matrix.push([]);
    }

    for (let i = 0; i < 5; i++) {
        let numbers = input[i].split(' ');
        for (let j = 0; j < 5; j++) {
            matrix[i][j] = parseInt(numbers[j]);
        }
    }

    for (let c in commands) {
        let com = commands[c].split(' ');
        let tempNum = parseInt(com[1]);
        if (com[0] == 'breeze') {
            for (let j = 0; j < 5; j++) {
                if (matrix[tempNum][j] - 15 >= 0)
                    matrix[tempNum][j] -= 15;
                else matrix[tempNum][j] = 0;
            }
        }
        else if (com[0] == 'gale') {
            for (let i = 0; i < 5; i++) {
                if (matrix[i][tempNum] - 20 >= 0)
                    matrix[i][tempNum] -= 20;
                else matrix[i][tempNum] = 0;

            }
        }
        else if (com[0] == 'smog') {
            for (let i = 0; i < 5; i++) {
                for (let j = 0; j < 5; j++) {
                    matrix[i][j] += tempNum;
                }
            }
        }
    }

    polutedAreas(matrix);

    function polutedAreas(input) {
        let boxes = [];
        for (let i = 0; i < 5; i++) {
            for (let j = 0; j < 5; j++) {
                let result = '[';
                if (matrix[i][j] >= 50) {
                    result += i + '-' + j + ']';
                    boxes.push(result);
                }
            }
        }
        console.log(boxes.length > 0 ? 'Polluted areas: ' + boxes.join(', ') : 'No polluted areas');
    }
}

solve([
    "5 7 72 14 4",
    "41 35 37 27 33",
    "23 16 27 42 12",
    "2 20 28 39 14",
    "16 34 31 10 24",
],
    ["breeze 1", "gale 2", "smog 25"]);