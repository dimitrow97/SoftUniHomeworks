function diagonalSums(input) {

    let main = 0, secondary = 0;

    for (let row = 0; row < input.length; row++) {
        main += input[row][row];
        secondary += input[row][input[row].length - row - 1];
    }

    console.log(`${main} ${secondary}`);
}