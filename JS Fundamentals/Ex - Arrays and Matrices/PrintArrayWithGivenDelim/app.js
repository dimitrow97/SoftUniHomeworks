function printArray(input) {
    let delim = input[input.length - 1];
    input.pop();

    let result = '';

    for (let i = 0; i < input.length; i++)
        if (i == 0) result += input[i];
        else result += delim + input[i];

    console.log(result);
}

printArray(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);