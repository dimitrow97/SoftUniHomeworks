function calculate(input) {
    function sum(input) {
        let sum = 0;
        for (let i = 0; i < input.length; i++)
            sum += input[i];
        return sum;
    }
    function sumInverse(input) {
        let sum = 0;
        for (let i = 0; i < input.length; i++)
            sum += (1 / input[i]);
        return sum;
    }
    function sumToString(input) {
        let result = '';
        for (let i = 0; i < input.length; i++)
            result += input[i];
        return result;
    }
    console.log(sum(input));
    console.log(sumInverse(input));
    console.log(sumToString(input));
}

calculate([2, 4, 8, 16]);