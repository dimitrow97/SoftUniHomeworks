function round(input) {
    if (input[1] > 15) {
        input[1] = 15;
    }
    input[0] = Number(input[0]).toFixed(input[1]);
    console.log(Number(input[0]));
}

round([10.5, 3]);