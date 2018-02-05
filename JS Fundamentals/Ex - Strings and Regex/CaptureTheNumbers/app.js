function capture(input) {
    let inputText = input.join(' ');
    let regex = /[0-9]+/g;
    let result = inputText.match(regex);
    console.log(result.join(' '));
}

capture(['The300', 'What is that?', 'I think it’s the 3rd movie.', 'Lets watch it at 22:45']);