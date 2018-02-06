function calculate(input) {
    let numbers = [], broken = 0;

    for (let i = 0; i < input.length; i++) {
        if (input[i] != '+' && input[i] != '-' && input[i] != '*' && input[i] != '/') {
            numbers.push(input[i]);
        }
        else {
            if (numbers.length <= 1) {
                console.log("Error: not enough operands!");
                broken = 1;
                break;
            }
            if (input[i] == '+') {
                let tempA = numbers.pop();
                let tempB = numbers.pop();
                numbers.push(tempB + tempA);
            }
            else if (input[i] == '-') {
                let tempA = numbers.pop();
                let tempB = numbers.pop();
                numbers.push(tempB - tempA);
            }
            else if (input[i] == '*') {
                let tempA = numbers.pop();
                let tempB = numbers.pop();
                numbers.push(tempB * tempA);
            }
            else if (input[i] == '/') {
                let tempA = numbers.pop();
                let tempB = numbers.pop();
                numbers.push(tempB / tempA);
            }
        }
    }

    if (broken == 0) {
        if (numbers.length == 1) console.log(numbers[0]);
        else console.log("Error: too many operands!");
    }
}

calculate([5, 3, 4, '*', '-']);
console.log("--------------------------------------");
calculate([15, '/']);
console.log("--------------------------------------");
calculate([7, 33, 8, '-']);
console.log("--------------------------------------");
calculate([31, 2, '+', 11, '/']);