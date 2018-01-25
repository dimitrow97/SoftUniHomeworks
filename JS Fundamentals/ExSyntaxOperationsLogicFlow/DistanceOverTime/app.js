function calculate(input) {
    let result = Math.abs((input[0] * (input[2] / 3600)) - (input[1] * (input[2]/3600)));
    console.log(result*1000);
}

calculate([0, 60, 3600]);