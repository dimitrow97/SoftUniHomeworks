function censorship(str, input) {
    let text = str;
    let forbiddenWords = input;
    for (let word of forbiddenWords) {
        text = text.split(word).join("-".repeat(word.length));
    }

    return text;
}