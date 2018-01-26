function toUpper(input) {
    var inputToUpper = input.toUpperCase();

    function extractWords(input) {
        return input.split(/\W+/);
    }

    var words = extractWords(inputToUpper);
    words = words.filter(w => w != '');
    console.log(words.join(', '));
}

toUpper('Hi, how are you?');