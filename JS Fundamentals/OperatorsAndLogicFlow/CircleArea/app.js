function circleArea(r) {
    let result = Math.PI * r * r;
    console.log(result);
    let resultRounded = Math.round(result * 100) / 100;
    console.log(resultRounded);
}

circleArea(5);