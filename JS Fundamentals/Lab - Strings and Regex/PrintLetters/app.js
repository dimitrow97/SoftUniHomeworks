function printLetters(input) {
    for (let letter in input)
        console.log('str[' + letter + '] -> ' + input[letter]);
}

printLetters('SoftUni');