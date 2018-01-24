function area(a, b, c) {
    let sp = (a + b + c) / 2;
    let result = Math.sqrt(sp * (sp - a) * (sp - b) * (sp - c));
    return result;
}

console.log(area(2, 3.5, 4));