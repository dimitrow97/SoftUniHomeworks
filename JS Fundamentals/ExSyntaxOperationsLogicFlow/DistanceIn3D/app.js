function dist3D(input) {
    let result = Math.sqrt(Math.pow((input[3] - input[0]), 2) + Math.pow((input[4] - input[1]), 2) + Math.pow((input[5] - input[2]), 2));
    return result;
}

console.log(dist3D([1, 1, 0, 5, 4, 0]));