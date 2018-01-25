function compoundInterest(input) {
    let compoundInterest = input[0] * Math.pow(1 + input[1] / (100 * (12 / input[2])), 12 / input[2] * input[3]);
    console.log(compoundInterest.toFixed(2));
}

compoundInterest([1500, 4.3, 3, 6]);